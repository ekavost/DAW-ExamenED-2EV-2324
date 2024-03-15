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
    public void TestMethod1()
    {
        string password = null;
        int resultExpected = -1;
        ComprobadorDePassword ComprobadorNull = new ComprobadorDePassword();
        Assert.AreEqual(resultExpected, ComprobadorNull.TestPassword(password));
    }

    [TestMethod]
    public void TestMethod2()
    {
        string password = "";
        int resultExpected = -1;
        ComprobadorDePassword ComprobadorEmpty = new ComprobadorDePassword();
        Assert.AreEqual(resultExpected, ComprobadorEmpty.TestPassword(password));
    }

    [TestMethod]
    [DataRow("A")]
    [DataRow("abc")]
    [DataRow("A2c4e")]

    public void TestMethod3(string password)
    {
        int resultExpected = 0;
        ComprobadorDePassword ComprobadorShort = new ComprobadorDePassword();
        Assert.AreEqual(resultExpected, ComprobadorShort.TestPassword(password));
    }
}
}
