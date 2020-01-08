using CadastroProdutos.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Value);
            builder.Property(c => c.Image);
            builder.Property(c => c.IsActive);
            builder.Property(c => c.CreatedAt).HasColumnType("DateTime");
            builder.Property(c => c.UpdatedAt).HasColumnType("DateTime");
        }
    }
}
