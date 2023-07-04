using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CartService.Domain.Entity;
using CartService.Infrastructure.Context;
using CartService.Infrastructure.Managers;

namespace CartService.Infrastructure.Extensions;

public static  class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services.AddManagers();
        services.AddDatabase(connectionString);
        return services;
    }

    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<ICartManager, CartManager>();
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CartContext>(builder => builder.UseNpgsql(connectionString));
        return services;
    }
}
