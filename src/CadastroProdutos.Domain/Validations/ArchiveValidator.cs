using FluentValidation;
using CadastroProdutos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos.Domain.Validations
{
    public class ArchiveValidator : AbstractValidator<Archive>
    {
        public ArchiveValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .WithMessage("Nome não pode ser vazio");

            RuleFor(a => a.Description)
                .NotNull()
                .WithMessage("Descrição não pode ser vazio");

            RuleFor(a => a.FileExtension)
                .NotNull()
                .WithMessage("Extensão do arquivo não identificada");

            RuleFor(a => a.FileName)
                .NotNull()
                .WithMessage("Arquivo não identificado");

            RuleFor(a => a.ArchiveType)
                .NotNull()
                .WithMessage("Tipo de media não identificado");
        }
    }
}