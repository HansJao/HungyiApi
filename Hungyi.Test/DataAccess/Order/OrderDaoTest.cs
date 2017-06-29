using Hungyi.DataAccess.Order;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.Test.DataAccess.Order
{
    [TestClass]
    public class OrderDaoTest
    {
        private string _dbConfig;
        [TestInitialize]
        public void TestInitialize()
        {
            _dbConfig = "Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;";
        }
        [TestMethod]
        public void GetOrderTest()
        {
            //Arrange
            OrderDao orderDao = new OrderDao(_dbConfig);

            var customerID = 1;
            //Act
            var actual = orderDao.GetOrder(customerID);
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual.Count);

        }

        [TestMethod]
        public void GetOrderDetailByOrderID()
        {
            //Arrange
            OrderDao orderDao = new OrderDao(_dbConfig);

            var orderID = 10;
            //Act
            var actual = orderDao.GetOrderDetailByOrderID(orderID);
            var expected = 7;
            //Assert
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            ////Arrange
            //UserDao userDao = new UserDao("Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;");
            //UserEntity userEntity = new UserEntity
            //{
            //    UserID = 1,
            //    UserName = "Hans",
            //    Gender = 1,
            //    UserAccount = "hans.jao",
            //    UserPassword = "1234",
            //    UserEmail = "vigor.jao@eitc.com.tw",
            //    UserCellphone = "0975669651",
            //    CreateDate = DateTime.Now,
            //    ModifyDate = DateTime.Now
            //};
            ////Act
            //var actual = userDao.UpdateUserByID(userEntity);
            //var expected = 1;
            ////Assert
            //Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetUserByAccountTest()
        {
            ////Arrange
            //UserDao userDao = new UserDao("Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;");

            ////Act
            //var actual = userDao.GetUserByAccount("hans.jao");
            //var expected = 1;
            ////Assert
            //Assert.AreEqual(expected, actual);
        }
    }
}
