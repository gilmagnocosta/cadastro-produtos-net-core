using System;

namespace CadastroProdutos.Domain.Entity
{
    public class RefreshToken
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Token { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
    }
}
