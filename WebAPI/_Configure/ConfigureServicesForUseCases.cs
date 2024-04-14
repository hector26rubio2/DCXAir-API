using Aplication.Validators;
using Application.Services.Implementation;
using Application.Services.Interface;
using Infrastructure.Repositories.Implementation;
using Infrastructure.Repositories.Interface;

namespace WebAPI._Configure
{
    public static class ConfigureServicesForUseCases
    {
        public static void AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            // Capa de Infraestructura
            services.AddScoped<IJourneyRepository, JourneyRepository>();

            // Capa de Aplicación
            services.AddScoped<IJourneyService,JourneyService> ();

            services.AddScoped<JourneyValidator>();
        }
       
    }
}
