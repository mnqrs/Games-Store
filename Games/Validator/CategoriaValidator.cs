using FluentValidation;
using Games.Model;

namespace Games.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator() {

            RuleFor(c => c.Genero)
                    .NotEmpty()
                    .MinimumLength(1)
                    .MaximumLength(250);
        }
    }
}
