using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using VestraCare.OrderManagement.Core.Application.Interfaces.Repository;

namespace VestraCare.OrderManagement.Infrastructure.Persistence.Repository
{
    public class SqlDbContext : ISqlDbContext
    {
        private readonly string? dbConnection;
        public SqlDbContext(IConfiguration configuration)
        {
            dbConnection = configuration.GetConnectionString("DBConnection");
        }
        public async Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters? parms = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (IDbConnection db = new SqlConnection(dbConnection))
            {
                return await db.QueryAsync<T>(sp, parms, commandType: commandType, commandTimeout: commandTimeout);
            }
        }
        public async Task<T?> GetAsync<T>(string sp, DynamicParameters? parms = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (IDbConnection db = new SqlConnection(dbConnection))
            {
                return await db.QueryFirstOrDefaultAsync<T>(sp, parms, commandType: commandType, commandTimeout: commandTimeout);
            }
        }
        public async Task<(IEnumerable<T1>, IEnumerable<T2>)> GetAllAsync<T1, T2>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (IDbConnection db = new SqlConnection(dbConnection))
            {
                using (var reader = await db.QueryMultipleAsync(sp, parms, commandType: commandType, commandTimeout: commandTimeout))
                {
                    return (await reader.ReadAsync<T1>(), await reader.ReadAsync<T2>());
                }
            }
        }
        public async Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>)> GetAllAsync<T1, T2, T3>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (IDbConnection db = new SqlConnection(dbConnection))
            {
                using (var reader = await db.QueryMultipleAsync(sp, parms, commandType: commandType, commandTimeout: commandTimeout))
                {
                    return (await reader.ReadAsync<T1>(), await reader.ReadAsync<T2>(), await reader.ReadAsync<T3>());
                }
            }
        }
        public async Task<int> ExecuteAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (IDbConnection db = new SqlConnection(dbConnection))
            {
                return await db.ExecuteAsync(sp, parms, commandType: commandType, commandTimeout: commandTimeout);
            }
        }
        public async Task<T?> ExecuteScalarAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (IDbConnection db = new SqlConnection(dbConnection))
            {
                return await db.ExecuteScalarAsync<T>(sp, parms, commandType: commandType, commandTimeout: commandTimeout);
            }
        }
    }
}
