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
    }
}
