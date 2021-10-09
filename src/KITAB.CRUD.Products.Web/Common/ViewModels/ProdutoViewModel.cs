using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using KITAB.CRUD.Products.Web.Extensions;

namespace KITAB.CRUD.Products.Web.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório...")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres...", MinimumLength = 2)]
        [RegularExpression(@"[^~""'`´!@#$%^&*()_={}[\]:;,.<>+\/?]+", ErrorMessage = "Alguns tipos de caracteres não são aceitos no campo {0}...")]
        [DisplayName("Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório...")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres...", MinimumLength = 2)]
        [RegularExpression(@"[^~""'`´!@#$%^&*()_={}[\]:;,<>+\/?]+", ErrorMessage = "Alguns tipos de caracteres não são aceitos no campo {0}...")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Imagem do Produto")]
        public IFormFile ImagemUpload { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo {0} é obrigatório...")]
        [DisplayName("Qtde. Estoque")]
        public int Qtde { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório...")]
        [DisplayName("Preço Custo")]
        public decimal PrecoCusto { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório...")]
        [DisplayName("Preço Venda")]
        public decimal PrecoVenda { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        [DisplayName("Situação")]
        public string Situacao { get; set; }
    }
}
