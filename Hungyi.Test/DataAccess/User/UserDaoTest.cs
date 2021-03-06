﻿using Hungyi.DataAccess.User;
using Hungyi.DataClass.User;
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

        [TestMethod]
        public void GetUserTest()
        {
            //Arrange
            UserDao userDao = new UserDao("Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;");

            //Act
            var actual = userDao.GetAllUser();
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            //Arrange
            UserDao userDao = new UserDao("Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;");
            UserEntity userEntity = new UserEntity
            {
                UserID = 1,
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
            var actual = userDao.UpdateUserByID(userEntity);
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetUserByAccountTest()
        {
            //Arrange
            UserDao userDao = new UserDao("Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;");

            //Act
            var actual = userDao.GetUserByAccount("hans.jao");
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
