using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello ";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello ";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from Acme Inc\r\nProduct:0001-Tools\r\nQuantity:1\r\nInstructions:Standard Delivery");
            //Act
            var actual = vendor.PlaceOrder(product, 1);
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_2Parameters()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from Acme Inc\r\nProduct:0001-Tools\r\nQuantity:1\r\nDeliver By:25/10/2019\r\nInstructions:Standard Delivery");
            //Act
            var actual = vendor.PlaceOrder(product, 1, new DateTimeOffset(2019, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_3Parameters()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from Acme Inc\r\nProduct:0001-Tools\r\nQuantity:1\r\nDeliver By:25/10/2019\r\nInstructions:Chain Saw");
            //Act
            var actual = vendor.PlaceOrder(product, 1, new DateTimeOffset(2019, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)), "Chain Saw");
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_WithAddress()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Test With Address");
            //Act
            var actual = vendor.PlaceOrder(product, 12, Vendor.IncludeAddress.yes, Vendor.SendCopy.no);
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_NoDeliveryDate()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from Acme Inc\r\nProduct:0001-Tools\r\nQuantity:12\r\nInstructions:Deliever to Suite 42");
            //Act
            var actual = vendor.PlaceOrder(product, 12, instructions: "Deliever to Suite 42");
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void ToString_test()
        {
            //Arrange
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "Vendor: ABC Corp";
            //Act
            var actual = vendor.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PrepareDirectionsTest()
        {
            //Arrange 
            var vendor = new Vendor();
            var expected = "Insert \r\n to define a new line";

            //Act
            var actual = vendor.PrepareDirections();
            Console.WriteLine(actual);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}