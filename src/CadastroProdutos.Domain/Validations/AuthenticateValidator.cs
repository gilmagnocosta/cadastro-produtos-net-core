using FluentValidation;
using CadastroProdutos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos.Domain.Validations
{
    public class AuthenticateValidator : AbstractValidator<User>
    {
        public AuthenticateValidator()
        {
            RuleFor(a => a.Password)
                .NotEmpty()
                .WithMessage("Digite a senha.");

            RuleFor(a => a.Person)
                .NotNull()
                .WithMessage("Digite os dados do usuário.");

            RuleFor(a => a.Person.FirstName)
                .NotEmpty()
                .WithMessage("Digite o primeiro nome.");

            RuleFor(a => a.Person.LastName)
                .NotEmpty()
                .WithMessage("Digite o ultimo nome.");

            RuleFor(a => a.Person.Contact)
                .NotNull()
                .WithMessage("Digite o email.");

            RuleFor(a => a.Person.Contact.Email)
                .NotEmpty()
                .WithMessage("Digite o email.");
        }
    }
}
