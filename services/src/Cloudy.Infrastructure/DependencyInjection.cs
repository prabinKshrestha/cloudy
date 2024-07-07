using Cloudy.Application.Common.Interfaces;
using Cloudy.Infrastructure.Data;
using Cloudy.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(TimeProvider.System);
        
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        services.AddDbContext<CloudyDbContext>((sp, options) => options
            .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .AddInterceptors(sp.GetServices<ISaveChangesInterceptor>())
        );

        services.AddScoped<ICloudyDbContext>(provider => provider.GetRequiredService<CloudyDbContext>());

        return services;
    }
}
