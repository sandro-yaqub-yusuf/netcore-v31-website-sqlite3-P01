using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using KITAB.CRUD.Products.Application.Notificadores;
using KITAB.CRUD.Products.Application.Produtos;
using KITAB.CRUD.Products.Domain.Models;
using KITAB.CRUD.Products.Infra.Paginacoes;
using KITAB.CRUD.Products.Web.ViewModels;

namespace KITAB.CRUD.Products.Web.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public ProdutosController(IProdutoService produtoService,
                                  INotificadorService notificadorService,
                                  IMapper mapper,
                                  IConfiguration config) : base(notificadorService)
        {
            _produtoService = produtoService;
            _mapper = mapper;
            _config = config;
        }

        [Route("produtos/lista")]
        [HttpGet]
        public IActionResult Index(int page, string sortField, string currentSortField, string currentSortOrder, string currentFilter, string filter)
        {
            if (_config.GetValue<bool>("StartProjectSettings:CreateTables:Produtos")) 
            {
                _produtoService.CriarTabelaProduto();
            }

            if (filter != null)
            {
                page = 1;
            }
            else
            {
                filter = currentFilter;
            }

            if (string.IsNullOrEmpty(sortField))
            {
                currentSortField = "Id";
                currentSortOrder = "ASC";
            }
            else
            {
                if (sortField != "*")
                {
                    if (currentSortField == sortField)
                    {
                        currentSortOrder = (currentSortOrder == "ASC" ? "DESC" : "ASC");
                    }
                    else
                    {
                        currentSortField = sortField;
                        currentSortOrder = "ASC";
                    }
                }
            }

            PaginacaoLista<Produto> _listaProdutos = _produtoService.ObterTodosPaginado(filter, (currentSortField + " " + currentSortOrder), page, 5);

            ViewBag.Paginacao = new PaginacaoDados {
                CurrentPage = _listaProdutos.PaginacaoDados.CurrentPage,
                HasNext = _listaProdutos.PaginacaoDados.HasNext,
                HasPrevious = _listaProdutos.PaginacaoDados.HasPrevious,
                PageSize = _listaProdutos.PaginacaoDados.PageSize,
                TotalCount = _listaProdutos.PaginacaoDados.TotalCount,
                TotalPages = _listaProdutos.PaginacaoDados.TotalPages,
                Filter = filter,
                SortField = currentSortField,
                SortOrder = currentSortOrder
            };

            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(_listaProdutos));
        }
        
        [Route("produtos/novo")]
        [HttpGet]
        public IActionResult Inserir()
        {
            return View();
        }

        [Route("produtos/novo")]
        [HttpPost]
        public IActionResult Inserir(ProdutoViewModel produtoViewModel)
        {
            // Faz a validação dos dados da camada de apresentação
            if (!ModelState.IsValid) return View(produtoViewModel);

            if (produtoViewModel.ImagemUpload != null)
            {
                var _imgPrefixo = (Guid.NewGuid() + "_");

                if (!UploadArquivo(produtoViewModel.ImagemUpload, _imgPrefixo)) return View(produtoViewModel);

                produtoViewModel.Imagem = (_imgPrefixo + produtoViewModel.ImagemUpload.FileName);
            }

            _produtoService.Inserir(_mapper.Map<Produto>(produtoViewModel));

            // Verifica se há notificações vinda da camada de negócio
            // Caso tenha notificações, devem ser exibidas ao usuário
            if (!OperacaoValida()) return View(produtoViewModel);

            return RedirectToAction("Index");
        }

        [Route("produtos/alterar/{id:int}")]
        [HttpGet]
        public IActionResult Alterar(int id)
        {
            ProdutoViewModel _produtoViewModel = _mapper.Map<ProdutoViewModel>(_produtoService.ObterPorId(id));

            if (_produtoViewModel == null) return NotFound();

            return View(_produtoViewModel);
        }

        [Route("produtos/alterar/{id:int}")]
        [HttpPost]
        public IActionResult Alterar(int id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            // Faz a validação dos dados da camada de apresentação
            if (!ModelState.IsValid) return View(produtoViewModel);

            if (produtoViewModel.ImagemUpload != null)
            {
                string _imgPrefixo = (Guid.NewGuid() + "_");

                if (!UploadArquivo(produtoViewModel.ImagemUpload, _imgPrefixo)) return View(produtoViewModel);

                produtoViewModel.Imagem = (_imgPrefixo + produtoViewModel.ImagemUpload.FileName);
            }

            _produtoService.Alterar(_mapper.Map<Produto>(produtoViewModel));

            // Verifica se há notificações vinda da camada de negócio
            // Caso tenha notificações, devem ser exibidas ao usuário
            if (!OperacaoValida()) return View(produtoViewModel);

            return RedirectToAction("Index");
        }

        [Route("produtos/consultar/{id:int}")]
        [HttpGet]
        public IActionResult Consultar(int id)
        {
            ProdutoViewModel _produtoViewModel = _mapper.Map<ProdutoViewModel>(_produtoService.ObterPorId(id));

            if (_produtoViewModel == null) return NotFound();

            return View(_produtoViewModel);
        }

        [Route("produtos/excluir/{id:int}")]
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ProdutoViewModel _produtoViewModel = _mapper.Map<ProdutoViewModel>(_produtoService.ObterPorId(id));

            if (_produtoViewModel == null) return NotFound();

            return View(_produtoViewModel);
        }

        [Route("produtos/excluir/{id:int}")]
        [HttpPost, ActionName("Excluir")]
        public IActionResult ExcluirProduto(int id)
        {
            ProdutoViewModel _produtoViewModel = _mapper.Map<ProdutoViewModel>(_produtoService.ObterPorId(id));

            if (_produtoViewModel == null) return NotFound();

            _produtoService.Excluir(id);

            // Verifica se há notificações vinda da camada de negócio
            // Caso tenha notificações, devem ser exibidas ao usuário
            if (!OperacaoValida()) return View(_produtoViewModel);

            TempData["Sucesso"] = "Produto excluido com sucesso !!!";

            return RedirectToAction("Index");
        }

        private bool UploadArquivo(IFormFile imagemUpload, string imgPrefixo)
        {
            if (imagemUpload.Length <= 0) return false;

            string _path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/produtos", imgPrefixo + imagemUpload.FileName);

            if (System.IO.File.Exists(_path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome !!!");

                return false;
            }

            using (FileStream _stream = new FileStream(_path, FileMode.Create))
            {
                imagemUpload.CopyToAsync(_stream);
            }

            return true;
        }
    }
}
