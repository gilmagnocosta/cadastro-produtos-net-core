using FluentValidation;
using CadastroProdutos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos.Domain.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Username)
                .NotEmpty()
                .WithMessage("Username é obrigatório");

            RuleFor(a => a.Password)
                .NotEmpty()
                .WithMessage("Digite a senha.");
        }
    }
}
