using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace WebApi.Domain.Abstract
{
    public interface IDapperHelper
    {
        Task ExecuteNotReturn(string query, DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null);
        Task<T> ExecuteReturnScalar<T>(string query, DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null);
        Task<IEnumerable<T>> ExecuteSqlReturnList<T>(string query, DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null);
        Task<IEnumerable<T>> ExecuteStoreProcedureReturnList<T>(string query, DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null);
    }
}
