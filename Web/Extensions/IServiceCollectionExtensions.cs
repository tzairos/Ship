
using ApplicationCore.Interfaces;

public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
        {
           services.AddScoped<IUserService,UserService>();
           services.AddScoped<IShipService,ShipService>();
            return services;
        }
    }