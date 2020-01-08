using System;
using System.Collections.Generic;
using CadastroProdutos.Application.ViewModel.Base;

namespace CadastroProdutos.Application.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string ImageURL { get; set; }
    }
}
