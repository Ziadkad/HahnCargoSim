using Backend.Services;
using Backend.Services.Interfaces;
using Backend.UnitOfService.Interfaces;

namespace Backend.UnitOfService;

public static class ServiceExtensions
{
    public static void AddUnitOfServices(this IServiceCollection services)
    {
        // Register individual services
        services.AddScoped<ICargoTransporterService, CargoTransporterService>();
        services.AddScoped<IGridService, GridService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ISimService, SimService>();
        services.AddScoped<IUserService, UserService>();

        // Register UnitOfService with its interface
        services.AddScoped<IUnitOfServices, UnitOfServices>();
    }
}