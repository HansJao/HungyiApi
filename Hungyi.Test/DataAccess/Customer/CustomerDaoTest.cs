using Hungyi.DataAccess.Customer;
using Hungyi.DataAccess.Textile;
using Hungyi.DataClass.Customer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hungyi.Test.DataAccess.Customer
{
    [TestClass]
    public class CustomerDaoTest
    {
        private string _dbConfig;
        [TestInitialize]
        public void TestInitialize()
        {
            _dbConfig = "Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;";
        }

        [TestMethod]
        public void GetCustomerTest()
        {
            //Arrange
            CustomerDao customerDao = new CustomerDao(_dbConfig);

            //Act
            var actual = customerDao.GetAllCustomer();
            var expected = 2;
            //Assert
            Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod]
        public void InsertCustomerTest()
        {
            //Arrange
            CustomerDao customerDao = new CustomerDao(_dbConfig);
            var customerEntity = new List<CustomerEntity>()
            {
                new CustomerEntity
                {
                    CustomerName = "采毓",
                    CustomerCellphone = "0912345678",
                    CustomerAddress = "板橋處",
                    CustomerTelephone = "0223456789",
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                 new CustomerEntity
                {
                    CustomerName = "東森",
                    CustomerCellphone = "0987654321",
                    CustomerAddress = "中和某處",
                    CustomerTelephone = "0223456789",
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                }

            };
            //Act
            int actual = customerDao.InsertCustomer(customerEntity);
            var expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
