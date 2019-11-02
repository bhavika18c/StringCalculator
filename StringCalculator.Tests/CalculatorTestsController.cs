using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using StringCalculator;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class CalculatorTestsController
    {
        [Test]
        public void AddEmptyString_RetuensFalse()
        {
            StringCalculator sc = new StringCalculator();
            var result = sc.Add("");
            Assert.AreEqual(0, result);
        }
    }
}
