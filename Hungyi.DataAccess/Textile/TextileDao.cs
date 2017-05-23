using Dapper;
using Hungyi.DataClass.Textile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Hungyi.DataAccess.Textile
{
    public class TextileDao : ITextileDao
    {
        private string _connectionString;
        public TextileDao(string connectionString)
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
        /// Gets all textile.
        /// </summary>
        /// <returns>
        /// 回傳所有布種資料
        /// </returns>
        public IEnumerable<TextileEntity> GetAllTextile()
        {
            IEnumerable<TextileEntity> textileEntity;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                textileEntity = dbCnnection.Query<TextileEntity>(@"SELECT * FROM [dbo].[Textile]");
            }
            return textileEntity;
        }

        public int InsertTextile(IEnumerable<TextileEntity> TextileData)
        {
            var result = 0;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                result = dbCnnection.Execute(@"INSERT INTO [dbo].[Textile]
                                                               ([ProductID]
                                                               ,[ImportUser]
                                                               ,[TextileName]
                                                               ,[TextileColor]
                                                               ,[TextileSpecification]
                                                               ,[Cost]
                                                               ,[Weight]
                                                               ,[IsSold]
                                                               ,[Price]
                                                               ,[Buyer]
                                                               ,[Stored]
                                                               ,[Remark]
                                                               ,[CreateDate]
                                                               ,[ModifyDate])
                                                               VALUES
                                                               (@ProductID,
                                                               @ImportUser,
                                                               @TextileName,
                                                               @TextileColor,
                                                               @TextileSpecification,
                                                               @Cost,
                                                               @Weight,
                                                               @IsSold,
                                                               @Price,
                                                               @Buyer,
                                                               @Stored,
                                                               @Remark,
                                                               @CreateDate,
                                                               @ModifyDate)", TextileData);
            }
            return result;
        }

        public int UpdateSoldTextile(IEnumerable<TextileEntity> TextileData)
        {
            var result = 0;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                result = dbCnnection.Execute(@"UPDATE [dbo].[Textile]
                                               SET                             
                                               [IsSold] = @IsSold,
                                               [Price] = @Price,
                                               [Buyer] = @Buyer,                                                  
                                               [Remark] = @Remark,
                                               [ModifyDate] = @ModifyDate
                                               WHERE 
                                               TextileID=@TextileID", TextileData);
            }
            return result;
        }
    }
}
