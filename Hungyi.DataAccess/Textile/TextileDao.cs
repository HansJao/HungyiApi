using Dapper;
using Hungyi.DataClass.Textile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Hungyi.DataClass.Product;
using System.Linq;

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
        /// Gets all product.
        /// </summary>
        /// <returns>
        /// 回傳所有商品資料
        /// </returns>
        public IEnumerable<ProductEntity> GetAllProduct()
        {
            IEnumerable<ProductEntity> productEntity;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                productEntity = dbCnnection.Query<ProductEntity>(@"SELECT * FROM [dbo].[Product]");
            }
            return productEntity;
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

        public IEnumerable<TextileEntity> GetTextileByListProductID(IEnumerable<int> productID)
        {
            IEnumerable<TextileEntity> textileEntity;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                var dynamicParams = new DynamicParameters();
                foreach (var id in productID)
                {
                    dynamicParams.Add("@ProductID", productID);
                }

                textileEntity = dbCnnection.Query<TextileEntity>(@"SELECT * FROM [dbo].[Textile] WHERE ProductID IN @ProductID", dynamicParams);
            }
            return textileEntity;
        }

        public IEnumerable<TextileEntity> GetTextileInfoByID(int productID)
        {
            IEnumerable<TextileEntity> textileEntity;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add("@ProductID", productID);
                textileEntity = dbCnnection.Query<TextileEntity>(@"SELECT * FROM [dbo].[Textile] WHERE ProductID = @ProductID", dynamicParams);
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
                var data = TextileData.ToList().Select(s => new
                {
                    IsSold = true,
                    Price = s.Price,
                    Remark = s.Remark,
                    ModifyDate = DateTime.Now,
                    TextileID = s.TextileID
                });
                dbCnnection.Open();
                result = dbCnnection.Execute(@"UPDATE [dbo].[Textile]
                                               SET                             
                                               [IsSold] = @IsSold,
                                               [Price] = @Price,                                             
                                               [Remark] = @Remark,
                                               [ModifyDate] = @ModifyDate
                                               WHERE 
                                               TextileID= @TextileID", data);
            }
            return result;
        }

        public int UpdateTextile(IEnumerable<TextileEntity> TextileData)
        {
            var result = 0;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                result = dbCnnection.Execute(@"UPDATE [dbo].[Textile]
                                               SET                             
                                               [TextileColor] = @TextileColor,
                                               [TextileSpecification] = @TextileSpecification,
                                               [Cost] = @Cost,  
                                               [Weight] = @Weight,
                                               [Stored] = @Stored,                                                
                                               [Remark] = @Remark,
                                               [ModifyDate] = GETDATE()
                                               WHERE 
                                               TextileID=@TextileID", TextileData);
            }
            return result;
        }
    }
}
