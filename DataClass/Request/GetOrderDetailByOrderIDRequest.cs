using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataClass.Request
{
    public class GetOrderDetailByOrderIDRequest
    {
        public int customerID { get; set; }
        public int orderID { get; set; }
    }
}
