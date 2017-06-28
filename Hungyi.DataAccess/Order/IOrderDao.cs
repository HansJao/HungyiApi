using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Order;

namespace Hungyi.DataAccess.Order
{
    public interface IOrderDao
    {
        int CreateOrder(ShipmentInfo shipmentInfo);
        int CreateOrderDetail(ShipmentInfo shipmentInfo, int orderID);
    }
}
