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
            int inventoryResult = subject.Inventory;

            //Assert
            Assert.AreEqual(50, inventoryResult);
        }

        [TestMethod]
        [DataRow(0, true)]
        [DataRow(1, false)]
        public void IsSoldOutWhenSoldOut(int inventory, bool expected)
        {
            // Arrange
            CateringItem subject = new CateringItem("B1", "Soda", 1.50, "B", inventory);

            // Act
            bool result = subject.IsSoldOut;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(1, 1D, 1D)]
        [DataRow(2, 2D, 4D)]
        [DataRow(5, 2D, 10D)]
        [DataRow(10, 20D, 200D)]
        public void TotalAmountMultipliesAmountByPrice(int amount, double price, double expected)
        {
            // Arrange
            CateringItem subject = new CateringItem("B1", "Soda", price, "B", amount);

            // Act
            double result = subject.TotalAmount;

            // Assert
            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void RemoveInventorySubtractsInventory()
        {
            // Arrange
            CateringItem subject = new CateringItem("B1", "Soda", 1.50, "B", 20);
            int expected = 15;

            // Act
            subject.RemoveInventory(5);

            // Assert
            Assert.AreEqual(expected, subject.Inventory);
        }

        [TestMethod]
        [DataRow("B", "beverage")]
        [DataRow("E", "entree")]
        [DataRow("A", "appetizer")]
        [DataRow("D", "dessert")]
        [DataRow("OHNO", "")]
        public void FullType(string code, string expected)
        {
            // Arrange
            CateringItem subject = new CateringItem("A7", "Soda", 1.50, code);

            // Act
            string result = subject.FullType();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
