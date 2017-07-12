using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Order;

namespace Hungyi.DataAccess.Order
{
    public interface IOrderDao
    {
        int CreateOrder(OrderEntity orderEntity);
        int CreateOrderDetail(ShipmentInfo shipmentInfo, int orderID);
        List<OrderEntity> GetOrder(int customerID);
        List<OrderDetailInfo> GetOrderDetailByOrderID(int orderID);
    }
}
