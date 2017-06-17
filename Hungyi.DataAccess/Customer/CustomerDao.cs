using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Customer;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Hungyi.DataAccess.Customer
{
    public class CustomerDao : ICustomerDao
    {
        private string _connectionString;
        public CustomerDao(string connectionString)
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
        public IEnumerable<CustomerEntity> GetAllCustomer()
        {
            IEnumerable<CustomerEntity> customerEntity;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                customerEntity = dbCnnection.Query<CustomerEntity>(@"SELECT * FROM [dbo].[Customer]");
            }
            return customerEntity;
        }

        public int InsertCustomer(IEnumerable<CustomerEntity> customerEntity)
        {
            var result = 0;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                result = dbCnnection.Execute(@"INSERT INTO [dbo].[Customer]
                                                               ([CustomerName]
                                                               ,[CustomerAddress]
                                                               ,[CustomerCellphone]
                                                               ,[CustomerTelephone]                                                               
                                                               ,[CreateDate]
                                                               ,[ModifyDate])
                                                               VALUES
                                                               (@CustomerName,
                                                               @CustomerAddress,
                                                               @CustomerCellphone,
                                                               @CustomerTelephone,
                                                               @CreateDate,
                                                               @ModifyDate)", customerEntity);
            }
            return result;
        }
    }
}
