using BloggingSite.API.Mapping.AutoMapper;
using BloggingSite.API.Services;

namespace BloggingSite.API.Data
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddAutoMapper(typeof(UserMappingProfile));
            // Add more services here as needed
        }
    }
}
