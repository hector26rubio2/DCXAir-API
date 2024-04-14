using Infrastructure;
namespace WebAPI._Configure
{
    public static class ConfigurationServices
    {
        public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddInfrastructure(configuration);
            services.AddUseCases(configuration);
            services.AddProfile();

        }
    }
}
