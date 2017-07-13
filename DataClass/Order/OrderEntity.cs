using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.User;

namespace Hungyi.DataClass.Order
{
    public class OrderEntity
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public string userName { get; set; }
        public int TotalPrice { get; set; }
        public int TotalCost { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
