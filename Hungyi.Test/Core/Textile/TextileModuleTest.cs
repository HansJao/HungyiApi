using Hungyi.Core.Textile;
using Hungyi.DataAccess.Textile;
using Hungyi.DataAccess.User;
using Hungyi.DataClass.Textile;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
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
            IConfiguration configuration = Substitute.For<IConfiguration>();
            configuration.GetValue<string>("DBInfo:ConnectionString").Returns("Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;");                  
            TextileModule textileModule = new TextileModule(configuration);

            //Act
            var actual = textileModule.GetAllTextileInfo();
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
