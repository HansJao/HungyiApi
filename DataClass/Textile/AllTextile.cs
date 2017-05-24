using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataClass.Textile
{
    public class AllTextile
    {
        public string TextileName { get; set; }
        public IEnumerable<TextileInfo> TextileInfo { get; set; }
    }

    public class TextileInfo
    {
        public string TextileColor { get; set; }
        public int Amount { get; set; }
    }
}
