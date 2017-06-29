using Hungyi.DataClass.Textile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataClass.Order
{
    public class ShipmentInfo
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public IEnumerable<TextileEntity> Textile { get; set; }
    }
}
