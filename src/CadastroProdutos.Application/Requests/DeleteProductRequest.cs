using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CadastroProdutos.Application.Requests
{
    public class DeleteProductRequest : IRequest<int?>
    {
        public int Id { get; set; }

        public DeleteProductRequest() { }

        public DeleteProductRequest(int id)
        {
            Id = id;
        }
    }
}
