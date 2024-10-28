using CleanCore.Domain.Actions.Product.Command;
using CleanCore.Domain.Interfaces.Services;
using CleanCore.Domain.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCore.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomainServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddMediatR(typeof(CreateProductCommand).Assembly);
            services.AddScoped<Notifications.Core.INotificationHandler, Notifications.Core.NotificationHandler>();
        }
    }
}