using FluentValidation;
using CadastroProdutos.Domain.Entity;

namespace CadastroProdutos.Domain.Validations
{
    public class AttractionCategoryValidator : AbstractValidator<AttractionCategory>
    {
        public AttractionCategoryValidator()
        {
            RuleFor(a => a.Description)
                .NotNull()
                .WithMessage("Campo descrição obrigatório");
        }
    }
}