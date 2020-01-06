using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CadastroProdutos.Application.Requests
{
    public class CreateAttractionRequest : IRequest<int?>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public decimal ServiceCharge { get; set; }
        public int AverageMinutes { get; set; }

        public CreateAttractionRequest() { }

        public CreateAttractionRequest(int categoryId, string name, string description, DateTime startTime, DateTime endTime, decimal price, decimal serviceCharge, int averageMinutes)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Price = price;
            ServiceCharge = serviceCharge;
            AverageMinutes = averageMinutes;

        }
    }
}
