using Hungyi.Core.Textile;
using Hungyi.DataAccess.Textile;
using Hungyi.DataAccess.User;
using Hungyi.DataClass.Textile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.Test.Core.Textile
{
    [TestClass]
    public class TextileModuleTest
    {
        private string _dbConfig;
        [TestInitialize]
        public void TestInitialize()
        {
            _dbConfig = "Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;";
        }
        [TestMethod]
        public void GetTetileTest()
        {
            //Arrange
            TextileDao textileDao = new TextileDao(_dbConfig);
            TextileModule textileModule = new TextileModule(textileDao);

            //Act
            var actual = textileModule.GetAllTextileInfo();
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
