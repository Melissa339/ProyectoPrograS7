using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using System;
using SistemaElecciones.Services;

namespace SistemaElecciones.Extensions
{
    public static class WebIocExtensions
    {
        public static void WebInjections(this IServiceCollection services)
        {
            services.AddMemoryCache().BuildServiceProvider();
            #region Application Services
            //En esta region se definen los servicios del backend a utilizar en los controladores del frontend
            //Ejemplo:
            //services.AddSingleton<IExampleServices, ExampleServices>();         
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICargoServices, CargoServices>();
            services.AddScoped<IPartidoServices, PartidoServices>();
            services.AddScoped<ICandidatoServices, CandidatoServices>();
            services.AddScoped<IMesaServices, MesaServices>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();
            //services.AddScoped<ICandidatoServices, CandidatoServices>();
            #endregion





        }
    }
}
