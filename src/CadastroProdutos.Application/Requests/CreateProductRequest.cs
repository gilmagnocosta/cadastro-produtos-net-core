using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CadastroProdutos.Application.Requests
{
    public class CreateProductRequest : IRequest<int?>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Image { get; set; }
        public IFormFile File { get; set; }

        public CreateProductRequest() { }

        public CreateProductRequest(string name, decimal value, string image)
        {
            Name = name;
            Value = value;
            Image = image;
        }
    }
}
