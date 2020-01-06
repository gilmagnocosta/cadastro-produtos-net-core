using FluentValidation;
using CadastroProdutos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos.Domain.Validations
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(a => a.CheckinAt)
                .NotNull()
                .NotEqual(DateTime.MinValue)
                .WithMessage("Escolha a data do check in.");

            RuleFor(a => a.CheckoutAt)
                .NotNull()
                .NotEqual(DateTime.MinValue)
                .WithMessage("Escolha a data do check out.");

            RuleFor(a => a.Attraction)
                .NotNull()
                .NotEmpty()
                .WithMessage("Deve ser escolhida a atração");

            RuleFor(a => a.Adults)
                .NotNull()
                .WithMessage("Quantidade de adultos não pode ser vazio");

            RuleFor(a => a.Children)
                .NotNull()
                .WithMessage("Quantidade de crianças não pode ser vazio");

            RuleFor(a => a.User)
                .NotNull()
                .WithMessage("O usuário não pode ser nulo.");
        }
    }
}