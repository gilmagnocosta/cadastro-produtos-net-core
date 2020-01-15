using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Domain.Interface.Service;
using CadastroProdutos.Domain.Notifications;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Service
{
    public class UserService : IUserService
    {
        private NotificationContext _notificationContext;

        public UserService(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public Task<User> Authenticate(string email, string password)
        {
            return null;
        }
    }
}