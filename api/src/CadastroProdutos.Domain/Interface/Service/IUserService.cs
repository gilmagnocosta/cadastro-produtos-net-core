using CadastroProdutos.Domain.Entity;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Interface.Service
{
    public interface IUserService
    {
        Task<User> Authenticate(string email, string password);
    }
}
