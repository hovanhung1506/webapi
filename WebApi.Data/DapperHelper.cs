using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApi.Domain.Abstract;

namespace WebApi.Data
{
    public class DapperHelper : IDapperHelper
    {
        private readonly string connectString = string.Empty;
        public DapperHelper(IConfiguration configuration)
        {
            connectString = configuration.GetConnectionString("ConnectionString");
        }

        public async Task ExecuteNotReturn(string query, DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null)
        {
            using (var dbConnect = new SqlConnection(connectString))
            {
                await dbConnect.ExecuteAsync(query, parameters, dbTransaction, commandType: CommandType.Text);
            }
        }

        public async Task<T> ExecuteReturnScalar<T>(string query, DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null)
        {
            using (var dbConnect = new SqlConnection(connectString))
            {
                return (T)Convert.ChangeType(await dbConnect.ExecuteScalarAsync<T>(query, parameters, dbTransaction, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        public async Task<IEnumerable<T>> ExecuteSqlReturnList<T>(string query, DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null)
        {
            using(var  dbConnect = new SqlConnection(connectString))
            {
                return await dbConnect.QueryAsync<T>(query, parameters, dbTransaction, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<T>> ExecuteStoreProcedureReturnList<T>(string query, DynamicParameters? parameters = null, IDbTransaction? dbTransaction = null)
        {
            using(var dbConnect = new SqlConnection(connectString))
            {
                return await dbConnect.QueryAsync<T>(query, parameters, dbTransaction, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
