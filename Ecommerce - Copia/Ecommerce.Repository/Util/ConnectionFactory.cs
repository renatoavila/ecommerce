using System;
using System.Data.SqlClient;

namespace Ecommerce.Repository.Util
{
    public class ConnectionFactory : IDisposable
    {
        private SqlConnection _conn;
        public SqlConnection GetConnection(string sqlConnection)
        {
            _conn = new SqlConnection(sqlConnection);
            _conn.Open();
            return _conn;
        }

        public void Dispose()
        {
            _conn.Dispose();
        }
    }
}
