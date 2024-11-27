using Dapper;
using System.Data;

namespace VestraCare.OrderManagement.Core.Application.Interfaces.Repository
{
    public interface ISqlDbContext
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters? parms = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        Task<T?> GetAsync<T>(string sp, DynamicParameters? parms = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        Task<(IEnumerable<T1>, IEnumerable<T2>)> GetAllAsync<T1, T2>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>)> GetAllAsync<T1, T2, T3>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        Task<int> ExecuteAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        Task<T?> ExecuteScalarAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
    }
}
