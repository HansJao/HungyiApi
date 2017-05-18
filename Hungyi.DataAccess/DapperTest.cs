using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Hungyi.DataAccess
{
    public class DapperTest
    {
        private string _connectionString;
        public DapperTest(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public void Add()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Product (ProductName) VALUES('testName')");
            }
        }
    }
}
