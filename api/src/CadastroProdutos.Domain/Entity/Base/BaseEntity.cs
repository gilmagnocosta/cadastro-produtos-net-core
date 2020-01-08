using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroProdutos.Domain.Entity.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        [NotMapped]
        public bool Valid { get; private set; }
        [JsonIgnore]
        [NotMapped]
        public bool Invalid => !Valid;
        [JsonIgnore]
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = CreatedAt;
            IsActive = true;
        }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}