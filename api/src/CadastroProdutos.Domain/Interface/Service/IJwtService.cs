using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Domain.Model;

namespace CadastroProdutos.Domain.Interface.Service
{
    public interface IJwtService
    {
        JsonWebToken CreateJWT(User user);
    }
}
