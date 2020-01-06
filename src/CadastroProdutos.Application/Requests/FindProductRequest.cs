using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using CadastroProdutos.Application.ViewModel;

namespace CadastroProdutos.Application.Requests
{
    public class FindAttractionRequest : IRequest<ProductViewModel>
    {
        public int Id { get; set; }

        public FindAttractionRequest() { }

        public FindAttractionRequest(int id)
        {
            Id = id;
        }
    }
}
