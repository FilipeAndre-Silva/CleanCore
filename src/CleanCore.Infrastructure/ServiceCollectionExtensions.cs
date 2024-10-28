using CleanCore.Domain.Interfaces.ReadRepositories;
using CleanCore.Domain.Interfaces.Repositories;
using CleanCore.Infrastructure.Data;
using CleanCore.Infrastructure.ReadRepositories;
using CleanCore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCore.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfraDependency(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddDbContext<CleanCoreDbContext>(options => options.UseSqlite("Data Source=CleanCore.db"));
        services.AddScoped<DapperConfiguration>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
    }
}