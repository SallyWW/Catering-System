using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        public void CateringInstanceShouldBeCreated()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act

            // Assert
            Assert.IsNotNull(catering);
        }

        [TestMethod]
        public void CateringListShouldBeEmptyWhenCreated()
        {
            //Arrange
            Catering subject = new Catering();

            //Act
            int result = subject.getItems().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void addCateringItemAddsItem()
        {
            // Arrange
            Catering subject = new Catering();
            CateringItem expected = new CateringItem("someCode", "someName", 4.2, "someType", 42);

            // Act
            subject.addCateringItem(expected);
            CateringItem result = subject.getItems()[0];

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ItemExistsWhenWeAddIt()
        {
            // Arrange
            Catering subject = new Catering();
            CateringItem item = new CateringItem("someCode", "someName", 4.2, "someType", 42);
            subject.addCateringItem(item);

            // Act
            bool result = subject.ItemExists(item.Code);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ItemDoesNotExistsWhenWeDontAddIt()
        {
            // Arrange
            Catering subject = new Catering();
            CateringItem item = new CateringItem("someCode", "someName", 4.2, "someType", 42);
            subject.addCateringItem(item);

            // Act
            bool result = subject.ItemExists("NotTheCodeWeExpected");

            // Assert
            Assert.IsFalse(result);
        }
    }
}
