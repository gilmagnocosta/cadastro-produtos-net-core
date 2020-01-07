using FluentValidation;
using CadastroProdutos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos.Domain.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .WithMessage("Nome não pode ser vazio");

            RuleFor(a => a.Value)
                .NotNull()
                .WithMessage("Valor não pode ser vazio");
        }
    }
}