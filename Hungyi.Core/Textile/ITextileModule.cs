using Hungyi.DataClass.Product;
using Hungyi.DataClass.Request.Textile;
using Hungyi.DataClass.Textile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.Core.Textile
{
    public interface ITextileModule
    {
        /// <summary>
        /// Gets all textile information.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AllTextile> GetAllTextileInfo();
        /// <summary>
        /// Gets the textile information by identifier.
        /// </summary>
        /// <param name="ProductID">The product identifier.</param>
        /// <returns></returns>
        IEnumerable<TextileEntity> GetTextileInfoByID(int ProductID);
        /// <summary>
        /// Gets all product.
        /// </summary>
        /// <returns>回傳所有商品資料</returns>
        IEnumerable<ProductEntity> GetAllProduct();

        /// <summary>
        /// Adds the textile list.
        /// </summary>
        /// <param name="TextileList">The textile list.</param>
        /// <returns>回傳是否成功</returns>
        bool AddTextileList(IEnumerable<TextileAddInfo> TextileList);

        /// <summary>
        /// Updates the textile.
        /// </summary>
        /// <param name="TextileList">The textile list.</param>
        /// <returns></returns>
        bool UpdateTextile(IEnumerable<TextileEntity> TextileList);
    }
}
