using System.Collections.Generic;
using KITAB.CRUD.Products.Domain.Models;
using KITAB.CRUD.Products.Infra.Paginacoes;

namespace KITAB.CRUD.Products.Application.Produtos
{
    public interface IProdutoService
    {
        void Inserir(Produto produto);
        void Alterar(Produto produto);
        void Excluir(int id);
        Produto ObterPorId(int id);
        List<Produto> ObterTodos();
        PaginacaoLista<Produto> ObterTodosPaginado(string filtro, string ordem, int pagina, int tamanhoPagina);
        void ExecuteSQL(string sql);
        void CriarTabelaProduto();
    }
}
