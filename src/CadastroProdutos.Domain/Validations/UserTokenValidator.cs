using FluentValidation;
using CadastroProdutos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos.Domain.Validations
{
    public class UserTokenValidator : AbstractValidator<UserToken>
    {
        public UserTokenValidator()
        {
            RuleFor(a => a.ExpirationDate)
                .NotNull()
                .NotEqual(DateTime.MinValue)
                .WithMessage("Expiration date is mandatory");

            RuleFor(a => a.Token)
                .NotEmpty()
                .NotNull()
                .WithMessage("Token is mandatory");

            RuleFor(a => a.User)
                .NotNull()
                .WithMessage("Invalid user");

        }
    }
}