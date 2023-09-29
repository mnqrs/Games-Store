using FluentValidation;
using Games.Model;

namespace Games.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {

            RuleFor(p => p.Nome)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(p => p.Descricao)
                .NotEmpty();

            RuleFor(p => p.Console)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(p => p.Preco)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.Foto)
                .MaximumLength(2000);

            RuleFor(p => p.Avaliacao)
                .GreaterThan(0);

        }
    }
}
