using CleanCore.Domain.Entities;

namespace CleanCore.Domain.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetAllAsync(int pageNumber, int pageSize);
}