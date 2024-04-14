using Aplication.AutoMapperProfiles;
using Application.AutoMapperProfiles;
using AutoMapper;

namespace WebAPI._Configure
{
    public static class ConfigureServicesProfile
    {
        public static void AddProfile(this IServiceCollection servicies)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<JourneyProfile>();
                cfg.AddProfile<TransportProfile>();
                cfg.AddProfile<FlightProfile>();


            });

            servicies.AddSingleton<IMapper>(new Mapper(configuration));
        }
    }
}
