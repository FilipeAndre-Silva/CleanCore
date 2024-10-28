using CleanCore.Domain.Entities;

namespace CleanCore.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync(int pageNumber, int pageSize);
        Task<Product> CreateAsync(Product product);
    }
}