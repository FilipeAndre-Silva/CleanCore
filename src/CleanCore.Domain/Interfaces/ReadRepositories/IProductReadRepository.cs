using CleanCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCore.Domain.Interfaces.ReadRepositories
{
    public interface IProductReadRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
