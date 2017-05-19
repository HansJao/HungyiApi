using Hungyi.DataAccess.Models;
using Hungyi.DataAccess.Textile;
using Hungyi.DataAccess.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.Test.DataAccess.User
{
    [TestClass]
    public class TetileDaoTest
    {
        private string _dbConfig;
        [TestInitialize]
        public void TestInitialize()
        {
            _dbConfig = "Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;";
        }
        [TestMethod]
        public void InsertUserTest()
        {
            //Arrange
            TextileDao textileDao = new TextileDao(_dbConfig);
            List<TextileEntity> textileEntity = new List<TextileEntity>
            {
               new TextileEntity
               {
                   ProductID =1,ImportUser=1,TextileName="1X1",
                   TextileColor="red",TextileSpecification="cool",Cost=100,
                   Weight=20,IsSold=false,Price=200,
                   Buyer=123,Stored="A",Remark="",
                   CreateDate = DateTime.Now,ModifyDate = DateTime.Now
               },
               new TextileEntity
               {
                   ProductID =2,ImportUser=1,TextileName="1X1",
                   TextileColor="red",TextileSpecification="cool",Cost=100,
                   Weight=20,IsSold=false,Price=200,
                   Buyer=123,Stored="A",Remark="",
                   CreateDate = DateTime.Now,ModifyDate = DateTime.Now
               }
            };
            //Act
            var actual = textileDao.InsertTextile(textileEntity);
            var expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetUserTest()
        {
            //Arrange
            TextileDao textileDao = new TextileDao(_dbConfig);

            //Act
            var actual = textileDao.GetAllTextile();
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            //Arrange
            UserDao userDao = new UserDao(_dbConfig);
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
    }
}
