using Application.Services.Implementation;
using Application.Services.Interface;
using Application.Validators;
using Infrastructure.Helpers.Implementation;
using Infrastructure.Helpers.Interfaces;
using Infrastructure.Repositories.Implementation;
using Infrastructure.Repositories.Interface;

namespace WebAPI._Configure
{
    public static class ConfigureServicesForUseCases
    {
        public static void AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            // Capa de Infraestructura
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IFlightsByType, FlightsByType>();
           

            // Capa de Aplicación
            services.AddScoped<IFlightService, FlightService>();

            services.AddScoped<FlightValidator>();
            services.AddScoped<FilterDTOValidator>();
            services.AddScoped<TransportValidator>();
        }
       
    }
}
