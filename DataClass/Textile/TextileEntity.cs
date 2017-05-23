using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataClass.Textile
{
    public class TextileEntity
    {
        public int TextileID { get; set; }
        public int ProductID { get; set; }
        public int ImportUser { get; set; }
        public string TextileName { get; set; }
        public string TextileColor { get; set; }
        public string TextileSpecification { get; set; }
        public int? Cost { get; set; }
        public int Weight { get; set; }
        public bool IsSold { get; set; }
        public int? Price { get; set; }
        public int? Buyer { get; set; }
        public string Stored { get; set; }
        public string Remark { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
