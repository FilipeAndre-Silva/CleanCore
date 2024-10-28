using CleanCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanCore.Infrastructure.Data;

public class CleanCoreDbContext : DbContext
{
    public CleanCoreDbContext(DbContextOptions<CleanCoreDbContext> options)
        : base(options)
    { }

    public DbSet<Product> Products { get; set; }
}