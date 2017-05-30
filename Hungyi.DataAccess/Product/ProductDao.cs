using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Product;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Hungyi.DataAccess.Product
{
    public class ProductDao : IProductDao
    {
        private string _connectionString;
        public ProductDao(string connectionString)
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
        /// <returns></returns>
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
        /// Inserts the product.
        /// </summary>
        /// <param name="productData">The product data.</param>
        /// <returns></returns>
        public int InsertProduct(IEnumerable<ProductEntity> productData)
        {
            var result = 0;
            using (IDbConnection dbCnnection = Connection)
            {
                dbCnnection.Open();
                result = dbCnnection.Execute(@"INSERT INTO [dbo].[Product]
                                                               (ProductName)
                                                               VALUES
                                                               (@ProductName)", productData);
            }
            return result;
        }
    }
}
