using Hungyi.DataAccess.Models;
using Hungyi.DataAccess.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.Test.DataAccess.User
{
    [TestClass]
    public class UserDaoTest
    {
        [TestMethod]
        public void InsertUserTest()
        {
            //Arrange
            UserDao userDao = new UserDao("Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;");
            UserEntity userEntity = new UserEntity
            {
                UserName = "Hans",
                Gender = 1,
                UserAccount = "hans.jao",
                UserPassword = "1234",
                UserEmail = "vigor.jao@eitc.com.tw",
                UserCellphone = "0975669651",
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now
            };
            //Act
            var actual = userDao.InsertUser(userEntity);
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
