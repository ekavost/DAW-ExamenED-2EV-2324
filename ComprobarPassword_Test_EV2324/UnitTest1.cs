using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ComprobadorDePasswordApp;

namespace UnitTestProject_EV2324
{
    [TestClass]
    public class UnitTestEV2324
    {
        [TestMethod]
        [DataRow("A2c4e6 ")]
        [DataRow("C0ntr@s ")]
        [DataRow("C0ntr@s3ñ@S3gur@")]
        public void TestMethodOk(string password)
        {
            ComprobadorDePassword ComprobadorOk = new ComprobadorDePassword();
            Assert.IsTrue(ComprobadorOk.TestPassword(password) > 0);
        }

    [TestMethod]
    [DataRow("")]
    [DataRow(null)]
    public void TestMethodError1(string password)
    {
            ComprobadorDePassword ComprobadorNull = new ComprobadorDePassword();
            try
            {
                ComprobadorNull.TestPassword(password);
            }
            catch (Exception error)
            {
                StringAssert.Contains(error.Message, ComprobadorNull.)
            }
    }

    [TestMethod]
    [DataRow("A")]
    [DataRow("abc")]
    [DataRow("A2c4e")]

    public void TestMethodError2(string password)
    {
        int resultExpected = 0;
        ComprobadorDePassword ComprobadorShort = new ComprobadorDePassword();
        Assert.AreEqual(resultExpected, ComprobadorShort.TestPassword(password));
    }
}
}
