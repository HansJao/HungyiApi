using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataAccess.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Hungyi.DataAccess.User
{
    public class UserDao : IUserDao
    {
        private string _connectionString;
        public UserDao(string connectionString)
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

        public int InsertUser(UserEntity userEntity)
        {
            var result = 0;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                result = dbConnection.Execute(@"INSERT INTO [dbo].[User]
                                            (UserName, 
                                            Gender, 
                                            UserAccount, 
                                            UserPassword,
                                            UserEmail, 
                                            UserCellPhone, 
                                            CreateDate, 
                                            ModifyDate)
                                            VALUES
                                            (@UserName, 
                                            @Gender, 
                                            @UserAccount, 
                                            @UserPassword, 
                                            @UserEmail, 
                                            @UserCellPhone, 
                                            @CreateDate, 
                                            @ModifyDate)", userEntity);
            }
            return result;
        }
    }
}
