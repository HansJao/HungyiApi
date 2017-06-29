using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataClass.Order
{
    public class OrderDetailInfo
    {
        public int Status { get; set; }
        public DateTime ModifyDate { get; set; }
        public string TextileName { get; set; }
        public string TextileColor { get; set; }
        public int Cost { get; set; }
        public float Weight { get; set; }
        public int Price { get; set; }

    }
}
