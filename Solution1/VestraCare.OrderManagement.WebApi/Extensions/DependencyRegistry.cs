using VestraCare.OrderManagement.Core.Application.Interfaces.Repository;
using VestraCare.OrderManagement.Core.Application.Interfaces.Services; 
using VestraCare.OrderManagement.Infrastructure.Persistence.Repository;

namespace VestraCare.OrderManagement.WebApi.Extensions
{
    internal static class DependencyRegistry
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSingleton<ISqlDbContext, SqlDbContext>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IOrderInfoRepository, OrderInfoRepository>(); 
            return services;
        }
    }
}
