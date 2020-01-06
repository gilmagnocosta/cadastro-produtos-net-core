using FluentValidation;
using CadastroProdutos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos.Domain.Validations
{
    public class AttractionValidator : AbstractValidator<Attraction>
    {
        public AttractionValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .WithMessage("Nome não pode ser vazio");

            RuleFor(a => a.Description)
                .NotNull()
                .WithMessage("Descrição não pode ser vazio");

            RuleFor(a => a.StartTime)
                .NotNull()
                .WithMessage("Data de inicio não pode ser vazio");

            RuleFor(a => a.EndTime)
                .NotNull()
                .WithMessage("Data fim não pode ser vazio");
        }
    }
}