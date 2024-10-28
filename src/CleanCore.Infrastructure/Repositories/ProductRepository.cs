using CleanCore.Domain.Entities;
using CleanCore.Domain.Interfaces.Repositories;
using CleanCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanCore.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly CleanCoreDbContext _context;
        public ProductRepository(CleanCoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            return await _context.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}