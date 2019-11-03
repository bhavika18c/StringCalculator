using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;


namespace StringCalculator.Tests
{
    [TestClass]
    public class CalculatorTestsController : IDisposable
    {
        private StringCalculator sc = new StringCalculator();

        [Test]
        public void AddEmptyString_RetuensFalse()
        {
            
            var result = StringCalculator.Calculate("");
            Assert.AreEqual(0, result);
        }
    }
}
