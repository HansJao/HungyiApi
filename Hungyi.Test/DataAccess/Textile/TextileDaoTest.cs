﻿using Hungyi.DataAccess.Textile;
using Hungyi.DataAccess.User;
using Hungyi.DataClass.Textile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.Test.DataAccess.User
{
    [TestClass]
    public class TextileDaoTest
    {
        private string _dbConfig;
        [TestInitialize]
        public void TestInitialize()
        {
            _dbConfig = "Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;";
        }
        [TestMethod]
        public void InsertTextileTest()
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
        public void GetTetileTest()
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
        public void UpdateSoldTextileTest()
        {

            //Arrange
            TextileDao textileDao = new TextileDao(_dbConfig);
            List<TextileEntity> textileEntity = new List<TextileEntity>
            {
               new TextileEntity
               {
                   TextileID = 2,
                   IsSold=true,
                   Price =200,
                   Buyer=123,
                   Remark ="",
                   ModifyDate = DateTime.Now
               },
               new TextileEntity
               {
                   TextileID = 4,
                   IsSold=false,
                   Price =300,
                   Buyer=641,
                   Remark ="Success",
                   ModifyDate = DateTime.Now
               }
            };
            //Act
            var actual = textileDao.UpdateSoldTextile(textileEntity);
            var expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTextileInfoByIDTest()
        {
            //Arrange
            TextileDao textileDao = new TextileDao(_dbConfig);
            int productId = 1;
            //Act
            var actual = textileDao.GetTextileInfoByID(productId);
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateTextileTest()
        {
            //Arrange
            TextileDao textileDao = new TextileDao(_dbConfig);
            List<TextileEntity> textileEntity = new List<TextileEntity>
            {
               new TextileEntity
               {
                   TextileID = 2,
                   TextileColor = "yellow",
                   TextileSpecification = "條紋",
                   Cost = 100,
                   Weight = 22.1f,
                   Stored = "A",
                   Remark =""
               },
               new TextileEntity
               {
                   TextileID = 3,
                   TextileColor = "yellow",
                   TextileSpecification = "條紋",
                   Cost = 100,
                   Weight = 20.7f,
                   Stored = "A",
                   Remark ="Success"
               }
            };
            //Act
            var actual = textileDao.UpdateTextile(textileEntity);
            var expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
