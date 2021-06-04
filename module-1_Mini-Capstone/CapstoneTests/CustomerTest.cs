using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void AccountBalanceReturnsZero()
        {
            //Arrange
            Customer subject = new Customer();

            //Act
            double accoutBalanceResult = subject.CurrentAccountBalance;

            //Assert
            Assert.AreEqual(0, accoutBalanceResult);
        }

        [TestMethod]
        public void ChangeBalanceReturns200()
        {
            //Arrange
            Customer subject = new Customer("Bob");

            //Act
            subject.ChangeBalance(200);
            double accoutBalanceResult = subject.CurrentAccountBalance;

            //Assert
            Assert.AreEqual(200, accoutBalanceResult);
        }
    }
}
