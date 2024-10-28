using CleanCore.Infrastructure.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCore.Infrastructure.ReadRepositories
{
    public class BaseDapperRepository<T> where T : class
    {
        private readonly DapperConfiguration _dapperConfig;

        public BaseDapperRepository(DapperConfiguration dapperConfig)
        {
            _dapperConfig = dapperConfig;
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object param = null)
        {
            using (var connection = _dapperConfig.CreateConnection())
            {
                connection.Open();
                try
                {
                    return await connection.QueryAsync<T>(sql, param);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro inesperado.", ex);
                }
            }
        }

    }
}
