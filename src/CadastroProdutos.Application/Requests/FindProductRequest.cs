using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using CadastroProdutos.Application.ViewModel;

namespace CadastroProdutos.Application.Requests
{
    public class FindProductRequest : IRequest<ProductViewModel>
    {
        public int Id { get; set; }

        public FindProductRequest() { }

        public FindProductRequest(int id)
        {
            Id = id;
        }
    }
}
