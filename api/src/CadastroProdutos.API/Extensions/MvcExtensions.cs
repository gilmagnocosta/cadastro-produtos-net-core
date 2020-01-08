using Microsoft.Extensions.DependencyInjection;
using CadastroProdutos.API.Filters;

namespace CadastroProdutos.API.Extensions
{
    public static class MvcExtensions
    {
        public static void AddCustomMvc(this IServiceCollection services)
        {
            AddNotificationFilter(services);
            AddUnitOfWorkFilter(services);
        }

        private static void AddNotificationFilter(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add<NotificationFilter>();

            });
        }

        private static void AddUnitOfWorkFilter(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add<UnitOfWorkActionFilter>();
            });
        }
    }
}
