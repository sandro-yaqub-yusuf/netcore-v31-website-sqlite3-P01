using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using KITAB.CRUD.Products.Application.Notificadores;
using KITAB.CRUD.Products.Application.Produtos;
using KITAB.CRUD.Products.Infra.Produtos;
using KITAB.CRUD.Products.Web.Extensions;

namespace KITAB.CRUD.Products.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<INotificadorService, NotificadorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            return services;
        }
    }
}
