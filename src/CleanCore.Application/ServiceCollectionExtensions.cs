using Microsoft.Extensions.DependencyInjection;
using CleanCore.Infrastructure;
using CleanCore.Domain;
using CleanCore.Application.Interfaces;
using CleanCore.Application.Services;

namespace CleanCore.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddInfraDependency();
        services.AddDomainServiceDependency();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IProductApplicationService, ProductApplicationService>();
    }
}