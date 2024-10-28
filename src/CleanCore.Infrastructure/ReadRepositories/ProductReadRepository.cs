using CleanCore.Domain.Entities;
using CleanCore.Domain.Interfaces.ReadRepositories;
using CleanCore.Infrastructure.Data;

namespace CleanCore.Infrastructure.ReadRepositories
{
    public class ProductReadRepository : BaseDapperRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(DapperConfiguration dapperConfig) : base(dapperConfig)
        {
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products";
            return await ExecuteQueryAsync<Product>(sql);
        }
    }
}