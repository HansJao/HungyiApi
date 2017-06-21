using Hungyi.DataClass.Product;
using Hungyi.DataClass.Textile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataAccess.Textile
{
    public interface ITextileDao
    {
        /// <summary>
        /// Inserts the textile.
        /// </summary>
        /// <param name="TextileData">The textile data.</param>
        /// <returns>回傳成功筆數</returns>
        int InsertTextile(IEnumerable<TextileEntity> TextileData);
        /// <summary>
        /// Gets all textile.
        /// </summary>
        /// <returns>回傳所有布種資料</returns>
        IEnumerable<TextileEntity> GetAllTextile();

        /// <summary>
        /// Updates the sold textile.
        /// </summary>
        /// <param name="TextileData">The textile data.</param>
        /// <returns>回傳成功筆數</returns>
        int UpdateSoldTextile(IEnumerable<TextileEntity> TextileData);

        /// <summary>
        /// Updates the textile.
        /// </summary>
        /// <param name="TextileData">The textile data.</param>
        /// <returns></returns>
        int UpdateTextile(IEnumerable<TextileEntity> TextileData);

        IEnumerable<TextileEntity> GetTextileInfoByID(int ProductID);
        /// <summary>
        /// Gets all product.
        /// </summary>
        /// <returns>回傳所有商品資料</returns>
        IEnumerable<ProductEntity> GetAllProduct();
        /// <summary>
        /// Gets the textile by list product identifier.
        /// </summary>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        IEnumerable<TextileEntity> GetTextileByListProductID(IEnumerable<int> productID);
    }
}
