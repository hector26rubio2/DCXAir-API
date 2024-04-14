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
           
                cfg.AddProfile<TransportProfile>();
                cfg.AddProfile<FlightProfile>();
                cfg.AddProfile<FilterProfile>();
                cfg.AddProfile<JourneyProfile>();
                


            });

            servicies.AddSingleton<IMapper>(new Mapper(configuration));
        }
    }
}
