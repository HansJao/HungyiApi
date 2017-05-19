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

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>回傳所有UserData</returns>
        public IEnumerable<UserEntity> GetAllUser()
        {
            IEnumerable<UserEntity> userEntity;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                userEntity = dbCnnection.Query<UserEntity>(@"SELECT * FROM [dbo].[User]");
            }
            return userEntity;
        }

        public UserEntity GetUserByAccount(string account)
        {
            UserEntity userEntity;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add("@UserAccount", account);
                userEntity = dbCnnection.QueryFirst<UserEntity>(@"SELECT * FROM [dbo].[User] WHERE UserAccount = @UserAccount", dynamicParams);
            }
            return userEntity;
        }

        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns>
        /// 回傳成功筆數
        /// </returns>
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

        /// <summary>
        /// 依據UserID更新User
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns>
        /// 回傳成功筆數
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int UpdateUserByID(UserEntity userEntity)
        {
            var result = 0;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                result = dbCnnection.Execute(@"UPDATE [dbo].[User]
                                               SET UserName = @UserName,                                              
                                               UserPassword = @UserPassword,
                                               UserEmail = @UserEmail,
                                               UserCellPhone = @UserCellPhone,                                              
                                               ModifyDate = @ModifyDate
                                               WHERE UserID = @UserID", userEntity);
            }
            return result;
        }
    }
}
