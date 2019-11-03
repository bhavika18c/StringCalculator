using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTestController
    {
        Calculate c = new Calculate();
       
        
        [TestMethod]
        public void addEmptyString_True()
        {
           var result =  c.CalculateString("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void addsingleNumber_Returns_True()
        {
            var result = c.CalculateString("5");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void addNewLine_ReturnsZero_True()
        {
            var result = c.CalculateString("\n");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void addWithNewLine_Returns_True()
        {
            var result = c.CalculateString("2\n5");
            Assert.AreEqual(7, result);
        }

        
        [TestMethod]
        public void addTwoNumber_Returns_True()
        {
            var result = c.CalculateString("20,50");
            Assert.AreEqual(70, result);
        }

             
        [TestMethod]
        public void addWithDelimiter_Returns_True() 
        {
            var result = c.CalculateString("//#\n7#5");
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void addingNegative_ThrowsException_Test1()
        {
            const string number = "2\n5,-7";
            try
            {
                var result = c.CalculateString(number);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Negative Number(s) are not allowed. You entered: -7 ", ex.Message);
            }
        }

        [TestMethod]
        public void addingNegative_ThrowsException_Test2()
        {
            Assert.ThrowsException<CalculatorException>(() => c.CalculateString("5,-8,-6,1"));
        }


        [DataTestMethod]
        [DataRow("20", 20)] // Requirement 1.1
        [DataRow("", 0)] // Requirement 1.2
        [DataRow("5,tytyt", 5)] // Requirement 1.3
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)] // Requirement 2.0
        [DataRow("1\n2,3", 6)] // Requirement 3.0
        [DataRow("2,1001,6", 8)] // Requirement 5.0
        [DataRow("//#\n2#5", 7)] // Requirement 6.1
        [DataRow("//,\n2,ff,100", 102)] // Requirement 6.2
        [DataRow("//[***]\n11***22***33", 66)] // Requirement 7.0
        [DataRow("//[*][!!][r9r]\n11r9r22*hh*33!!44", 110)] // Requirement 8.0
        public void allRequirementsTest_Result_True(string number, int result)
        {
            Assert.AreEqual(result, c.CalculateString(number));
        }





    }
}
