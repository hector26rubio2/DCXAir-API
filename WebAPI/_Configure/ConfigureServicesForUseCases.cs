using Aplication.Services.Implementation;
using Aplication.Services.Interface;
using Aplication.Validators;
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

            // Capa de Aplicación
            services.AddScoped<IFlightService, FlightService>();

            services.AddScoped<FlightValidator>();
            services.AddScoped<FilterDTOValidator>();
            services.AddScoped<TransportValidator>();
        }
       
    }
}
