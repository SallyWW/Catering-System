using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CateringItemTest
    {
        [TestMethod]
        public void CateringItemIncludesNameProperty()
        {
            //Arrange
            CateringItem subject = new CateringItem("B1", "Soda", 1.50, "B");

            //Act
            string nameResult = subject.Name;

            //Assert
            Assert.AreEqual("Soda", nameResult);
        }

        [TestMethod]
        public void CateringItemIncludesPriceProperty()
        {
            //Arrange
            CateringItem subject = new CateringItem("B1", "Soda", 1.50, "B");

            //Act
            double priceResult = subject.Price;

            //Assert
            Assert.AreEqual(1.50, priceResult);
        }

        [TestMethod]
        public void CateringItemInventoryDefaultsTo50()
        {
            //Arrange
            CateringItem subject = new CateringItem("B1", "Soda", 1.50, "B");

            //Act
            int inventoryResult = subject.inventory;

            //Assert
            Assert.AreEqual(50, inventoryResult);
        }
    }
}
