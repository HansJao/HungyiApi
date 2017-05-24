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

        IEnumerable<TextileEntity> GetTextileInfoByID(int ProductID);
    }
}
