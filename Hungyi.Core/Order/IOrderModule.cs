using Hungyi.DataClass.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Order;

namespace Hungyi.Core.Order
{
    public interface IOrderModule
    {
        int CreateOrder(ShipmentInfo shipmentInfo);
        List<OrderEntity> GetOrder(int customerID);
        List<OrderDetailInfo> GetOrderDetailByOrderID(int orderID);
    }
}
