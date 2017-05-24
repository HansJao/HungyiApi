using Hungyi.DataClass.Textile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.Core.Textile
{
    public interface ITextileModule
    {
        IEnumerable<AllTextile> GetAllTextileInfo();
    }
}
