using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CadastroProdutos.Domain.Interface.Repository;
using CadastroProdutos.Domain.Interface.Service;
using CadastroProdutos.Domain.Model;
using CadastroProdutos.Domain.Notifications;
using CadastroProdutos.Domain.Service;
using CadastroProdutos.Infra.Data.Interface;
using CadastroProdutos.Infra.Data.Repository;
using CadastroProdutos.Infra.Data.UnitOfWork;
using CadastroProdutos.Infra.Utils.Images;
using CadastroProdutos.Settings;

namespace CadastroProdutos.Infra.IoC
{
    public class InjectorConfig
    {
        static IConfiguration _configuration;

        public InjectorConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            /** Services **/
            services.AddScoped<IArchiveService, ArchiveService>();
            services.AddScoped<IAttractionCategoryService, AttractionCategoryService>();
            services.AddScoped<IAttractionService, AttractionService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();

            /** Repositorios **/
            services.AddScoped<IArchiveRepository, ArchiveRepository>();
            services.AddScoped<IAttractionCategoryRepository, AttractionCategoryRepository>();
            services.AddScoped<IAttractionRepository, AttractionRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IProductRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserTokenRepository, ProductRepository>();

            services.AddScoped<ImageHelper>();
            
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<JwtSettings>();

            services.AddScoped<NotificationContext>();
        }
    }
}
