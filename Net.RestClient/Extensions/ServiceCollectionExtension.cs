using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Net.RestClient.Models.Entities;
using Net.RestClient.Models.interfaces;
using Net.RestClient.Models.ValueObjects;

namespace Net.RestClient.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Add RestClient to the service container
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">RestClientConfiguration</param>
        /// <returns></returns>
        public static IServiceCollection AddRestClient(this IServiceCollection services,
            RestClientConfiguration configuration)
        {
            services.AddHttpInterfaces(configuration);
            services.AddScoped<IRestClient>(x => 
                new Models.Entities.RestClient(x.GetService<IHttpGet>(),
                x.GetService<IHttpPost>(),
                x.GetService<IHttpPut>(),
                x.GetService<IHttpDelete>())
            );
            return services;
        }
        
        /// <summary>
        /// Add Http Interfaces to service collection
        /// </summary>
        /// <param name="services">IServiceConfiguration</param>
        /// <returns>Service Collections</returns>
        private static IServiceCollection AddHttpInterfaces(this IServiceCollection services,RestClientConfiguration configuration)
        {
            services.AddScoped<IHttpGet>(x=>new HttpGet(configuration));
            services.AddScoped<IHttpPost>(x=>new HttpPost(configuration));
            services.AddScoped<IHttpPut>(x=>new HttpPut(configuration));
            services.AddScoped<IHttpDelete>(x => new HttpDelete(configuration));
            return services;
        }
    }
}