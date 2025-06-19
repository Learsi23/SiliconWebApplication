using Infrastructure.Services;
using System.Runtime.CompilerServices;

namespace SiliconWebApplication.Configurations;

public static class ServiceConfiguration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<AddressServices>();
        services.AddScoped<CategoryService>();
        services.AddScoped<CourseService>();
        services.AddScoped<AccountService>();
    }

}
