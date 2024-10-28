using CleanCore.Domain.Interfaces.Repositories;

namespace CleanCore.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly CleanCoreDbContext _context;

    public UnitOfWork(CleanCoreDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Adicionar notificação sobre o erro
            return default;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}