using App.Data;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace App.Infrastructure
{
    public interface IQueryExecutor
    {
        IEnumerable<T> ExecuteQuery<T>(string sql);
        IEnumerable<T> ExecuteQuery<T>(string sql, object parametrs);
        T ExecuteSingle<T>(string sql);
        T ExecuteSingle<T>(string sql, object parametrs);
    }

    public class QueryExecutor : IQueryExecutor
    {
        private readonly string _connectionString;

        public QueryExecutor(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> ExecuteQuery<T>(string sql) =>
            ExecuteQuery<T>(sql, null);

        public T ExecuteSingle<T>(string sql) =>
            ExecuteSingle<T>(sql, null);

        public IEnumerable<T> ExecuteQuery<T>(string sql, object parametrs)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(sql, param: parametrs);
            }
        }

        public T ExecuteSingle<T>(string sql, object parametrs)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(sql, param: parametrs).Single();
            }
        }

        private SqlConnection CreateConnection() =>
            new SqlConnection(ConfigurationSetup.IdbConnectionString);
    }
}
