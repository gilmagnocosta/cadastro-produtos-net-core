using CadastroProdutos.Domain.Entity.Base;

namespace CadastroProdutos.Domain.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Image { get; set; }
    }
}
