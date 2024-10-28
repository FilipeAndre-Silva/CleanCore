using CleanCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CleanCore.Infrastructure.Data
{
    public class DapperConfiguration
    {
        private readonly CleanCoreDbContext _context;

        public DapperConfiguration(CleanCoreDbContext context)
        {
            _context = context;
        }

        public IDbConnection CreateConnection()
        {
            // Obtém a conexão do DbContext e garante que a conexão esteja aberta
            var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
    }
}