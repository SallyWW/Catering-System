using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class TransactionLogTest
    {
        [TestMethod]
        public void TransactionLogConstructor()
        {
            // Arrange
            string name = "name";
            double amount = 4.2;
            double remainingAmount = 4.1;
            DateTime transactionTime = new DateTime();

            // Act
            TransactionLog log = new TransactionLog(name, amount, remainingAmount, transactionTime);

            // Assert
            Assert.IsTrue(log.TransactionName == name &&
                log.TransactionAmount == amount &&
                log.TotalRemainingAmount == remainingAmount &&
                log.TransactionDateTime == transactionTime);


        }

    }
}
