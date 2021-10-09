using FluentValidation;
using KITAB.CRUD.Products.Domain.Models;

namespace KITAB.CRUD.Products.Application.Produtos
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido...")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres...");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido...")
                .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres...");

            RuleFor(c => c.Imagem)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido...")
                .Length(5, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres...");

            RuleFor(c => c.PrecoCusto)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}...");

            RuleFor(c => c.PrecoVenda)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}...");
        }
    }
}
