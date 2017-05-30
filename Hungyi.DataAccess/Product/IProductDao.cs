using Hungyi.DataClass.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataAccess.Product
{
    public interface IProductDao
    {
        /// <summary>
        /// Gets all product.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductEntity> GetAllProduct();
        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="productData">The product data.</param>
        /// <returns></returns>
        int InsertProduct(IEnumerable<ProductEntity> productData);

    }
}
