using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace CadastroProdutos.Application.Requests
{
    public class UploadMediaAttractionRequest : IRequest<int?>
    {
        public int AttractionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public IFormFile File { get; set; }

        public UploadMediaAttractionRequest() { }

        public UploadMediaAttractionRequest(int attractionId, string name, bool isMain, IFormFile file)
        {
            AttractionId = attractionId;
            Name = name;
            IsMain = isMain;
            File = file;
        }
    }
}
