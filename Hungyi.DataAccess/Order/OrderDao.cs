using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Hungyi.DataClass.Order;
using Dapper;
using System.Linq;

namespace Hungyi.DataAccess.Order
{
    public class OrderDao : IOrderDao
    {
        private string _connectionString;
        public OrderDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public int CreateOrder(ShipmentInfo shipmentInfo)
        {
            int orderID = 0;
            using (IDbConnection dbCnnection = Connection)
            {
                var textileList = shipmentInfo.Textile.ToList();
                var data = new
                {
                    CustomerID = shipmentInfo.CustomerID,
                    UserID = 2,
                    TotalPrice = textileList.Sum(s => s.Price),
                    TotalCost = textileList.Sum(s => s.Cost),
                    TotalQuantity = textileList.Count(),
                    CreateDate = DateTime.Now
                };
                dbCnnection.Open();
                orderID = dbCnnection.QueryFirst<int>(@"INSERT INTO [dbo].[Order]
                                                               ([CustomerID]
                                                              ,[UserID]
                                                              ,[TotalPrice]
                                                              ,[TotalCost]
                                                              ,[TotalQuantity]
                                                              ,[CreateDate])
                                                               VALUES
                                                               (@CustomerID,
                                                               @UserID,
                                                               @TotalPrice,
                                                               @TotalCost,
                                                               @TotalQuantity,
                                                               @CreateDate);
                                                               SELECT CAST(SCOPE_IDENTITY() as int)", data);
            }
            return orderID;
        }

        public int CreateOrderDetail(ShipmentInfo shipmentInfo,int orderID)
        {
            var result = 0;
            using (IDbConnection dbCnnection = Connection)
            {
                var data = shipmentInfo.Textile.ToList().Select(s=>new 
                {
                    OrderID = orderID,
                    TextileID = s.TextileID,
                    Status = 1,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                });
                dbCnnection.Open();
                result = dbCnnection.Execute(@"INSERT INTO [dbo].[OrderDetail]
                                                               ([OrderID]
                                                              ,[TextileID]
                                                              ,[Status]
                                                              ,[CreateDate]
                                                              ,[ModifyDate])
                                                               VALUES
                                                               (@OrderID,
                                                               @TextileID,
                                                               @Status,
                                                               @CreateDate,
                                                               @ModifyDate)", data);
            }
            return result;
        }
    }
}
