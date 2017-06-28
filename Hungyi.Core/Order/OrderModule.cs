using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataClass.Product;
using Hungyi.DataAccess.Product;
using Microsoft.Extensions.Configuration;
using Hungyi.DataAccess.Textile;
using Hungyi.DataAccess.Order;
using Hungyi.DataClass.Order;

namespace Hungyi.Core.Order
{
    public class OrderModule : IOrderModule
    {
        private IOrderDao _orderDao;
        private ITextileDao _textileDao;
        private IConfiguration _configuration;

        public OrderModule(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        protected IOrderDao OrderDao
        {
            get
            {
                if (this._orderDao == null)
                {
                    this._orderDao = new OrderDao(_configuration.GetValue<string>("DBInfo:ConnectionString"));
                }
                return this._orderDao;
            }
            set
            {
                this._orderDao = value;
            }
        }
        protected ITextileDao TextileDao
        {
            get
            {
                if (this._textileDao == null)
                {
                    this._textileDao = new TextileDao(_configuration.GetValue<string>("DBInfo:ConnectionString"));
                }
                return this._textileDao;
            }
            set
            {
                this._textileDao = value;
            }
        }

        public int CreateOrder(ShipmentInfo shipmentInfo)
        {
            int orderID = OrderDao.CreateOrder(shipmentInfo);
            int successCount = OrderDao.CreateOrderDetail(shipmentInfo,orderID);
            return orderID;
        }
    }
}
