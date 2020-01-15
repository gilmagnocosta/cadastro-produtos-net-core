using CadastroProdutos.Domain.Entity.Base;
using CadastroProdutos.Domain.Validations;

namespace CadastroProdutos.Domain.Entity
{
    public class User : BaseEntity
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;

            Validate(this, new UserValidator());
        }
    }
}
