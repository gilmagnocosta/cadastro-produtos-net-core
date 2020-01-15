using CadastroProdutos.Domain.Entity;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Interface.Service
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> GetByToken(string token);
        Task Save(RefreshToken refreshToken);
    }
}
