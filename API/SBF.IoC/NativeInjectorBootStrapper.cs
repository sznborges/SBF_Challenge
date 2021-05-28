using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SBF.Domain.Interfaces.Repository;
using SBF.Domain.Interfaces.Services;
using SBF.Domain.Services;
using SBF.Infra.Data;
using SBF.Infra.Repository;

namespace SBF.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Services
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IConversorMoedaService, ConversorMoedaService>();

            //Infra
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<Context>();

            //Flurl
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
        }
    }
}
