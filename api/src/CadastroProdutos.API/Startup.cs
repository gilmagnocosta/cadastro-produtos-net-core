using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CadastroProdutos.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using CadastroProdutos.Infra.IoC;
using AutoMapper;
using MediatR;
using CadastroProdutos.API.Filters;
using Microsoft.AspNetCore.Mvc;
using CadastroProdutos.API.Extensions;
using CadastroProdutos.Settings;

namespace CadastroProdutos.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        readonly string _corsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(_configuration.GetConnectionString("CadastroContext")));

            InjectorConfig.RegisterServices(services, _configuration);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMediatR(AppDomain.CurrentDomain.Load("CadastroProdutos.Application"));
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("CadastroProdutos.Application"));
            services.AddScoped<UnitOfWorkActionFilter>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicy,
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddCustomMvc();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_corsPolicy);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AppHttpHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        }
    }
}
