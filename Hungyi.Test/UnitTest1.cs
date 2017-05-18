using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hungyi.DataAccess;

namespace Hungyi.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            DapperTest dapperTest = new DapperTest("Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;");
            dapperTest.Add();
        }
    }
}
