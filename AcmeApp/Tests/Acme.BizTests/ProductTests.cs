using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.BizTests
{
        [TestClass()]
        public class ProductTests
        {

        [TestMethod()]

            public void SayHelloTest()
            {
                //Arrange
                var currentProduct = new Product();
                currentProduct.ProductName = "Saw";
                currentProduct.ProductId = 1;
                currentProduct.Description = "15-inch steel blade hand saw";
                currentProduct.ProductVendor.CompanyName = "ABC Corp";
                var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

                //Act
                var actual = currentProduct.SayHello();

                //Assert
                Assert.AreEqual(expected, actual);
            }

          [TestMethod()]

            public void SayHello_ParameterizedConstructor()
            {
                //Arrange
                var currentProduct = new Product(1, "Saw",
                                    "15-inch steel blade hand saw");
                var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

                //Act
                var actual = currentProduct.SayHello();

                //Assert
                Assert.AreEqual(expected, actual);
            }

        [TestMethod()]

            public void SayHello_ObjectInitilalizer()
            {
            //Arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15-inch steel blade hand saw",
            };

            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
            }

        [TestMethod()]

            public void Product_Null()
            {
            //Arrange
                Product currentProduct = null;
                var companyName = currentProduct?.ProductVendor?.CompanyName;

                string expected = null;

                //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
    
            }

        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            //Arrange
            var expected = 78.74;
            //Act
            var actual = 2 * Product.inchesInMetre;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Default()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = .96m;
            //Act
            var actual = currentProduct.MinimumPrice;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Param()
        {
            //Arrange
            var currentProduct = new Product(1, "Bulk Tools", "");
            var expected = 9.99m;
            //Act
            var actual = currentProduct.MinimumPrice;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_Format()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "   Claw Hammer    ";
            var expected = "Claw Hammer";
            //Act
            var actual = currentProduct.ProductName?.Trim();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_ValidationTooShort()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "ch";
            var expected = "Product Name must be at least 3 characters";
            //Act
            var actual = currentProduct.ValidationMessage;
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ProductName_ValidationTooLong()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "1234567891011121314151617181920";
            var expected = "Product Name must be more than 20 characters";

            //Act
            var actual = currentProduct.ValidationMessage;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_JustRight()
        {
            //Arange
            var currentProduct = new Product();
            currentProduct.ProductName = "Chain Saw";
            string expected = "Chain Saw";
            string expectedMessage = null;
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);

        }

        [TestMethod()]
        public void ProductCategory_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = "Tools";
            //Act
            var actual = currentProduct.ProductCategory;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductCategory_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductCategory = "Food";
            var expected = "Food";
            //Act
            var actual = currentProduct.ProductCategory;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SequenceNumber_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = 1;
            //Act
            var actual = currentProduct.SequnceNumber;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SequenceNumber_NewValue()
        {
            //Arange
            var currentProduct = new Product();
            currentProduct.SequnceNumber = 3;
            var expected = 3;
            //Act
            var actual = currentProduct.SequnceNumber;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductCode_Check()
        {
            //Assign
            var currentProduct = new Product();
            currentProduct.SequnceNumber = 1;
            currentProduct.ProductCategory = "Tools";
            var expected = "1-Tools";
            //Act
            var actual = currentProduct.ProductCode;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductPrice_Check()
        {
            //Assign
            var product = new Product(50, "Saw", "");
            product.ProductCost = 50;
            var expected = 55m;
            //Act
            var actual = product.CalculatedSuggestedPrice(10m);
            //Assert
            Assert.AreEqual(expected, actual);
        }
     
        }
    }
