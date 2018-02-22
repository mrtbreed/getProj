using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Edit_Product()
        {
            //Arrange - create mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1" },
                new Product {ProductID = 2, Name = "P2" },
                new Product {ProductID = 3, Name = "P3" },
            });

            //Arrange Create Controler Edit
            AdminController target = new AdminController(mock.Object);

            //Act
            Product p1 = target.Edit(1).ViewData.Model as Product;
            Product p2 = target.Edit(2).ViewData.Model as Product;
            Product p3 = target.Edit(3).ViewData.Model as Product;

            //Assert
            Assert.AreEqual(1, p1.ProductID);
            Assert.AreEqual(2, p2.ProductID);
            Assert.AreEqual(3, p3.ProductID);
        }
        [TestMethod]
        public void Cannot_Edit_Nonexistant_Product()
        {
            //Arrangemock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1" },
                 new Product {ProductID = 2, Name = "P2" },
                  new Product {ProductID = 3, Name = "P3" },
            });

            //Arrange contrlr
            AdminController target = new AdminController(mock.Object);
            Product result = (Product)target.Edit(4).ViewData.Model;

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            //Arrange mock repstry
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //Cntrlr
            AdminController target = new AdminController(mock.Object);
            //Arrange, create product
            Product product = new Product { Name = "Test" };

            //Act try to save product
            ActionResult result = target.Edit(product);

            //Assert check the repository was called
            mock.Verify(m => m.SaveProduct(product));
            //Asseart check method result type
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            //Arrange mock rpstry
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //Arrange contrlr
            AdminController target = new AdminController(mock.Object);
            //Arrange-create a product
            Product product = new Product { Name = "Test" };
            //Arrange model error state
            target.ModelState.AddModelError("error", "error");

            //Act try to save product
            ActionResult result = target.Edit(product);

            //Assert check repository wasnt called
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            //Assert check method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }
        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            //Arrange creat product
            Product prod = new Product { ProductID = 2, Name = "Test" };

            //arrange mock
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1" },
                prod,
                new Product {ProductID = 3, Name = "P3" },
            });

            //arrange create controller
            AdminController target = new AdminController(mock.Object);

            //act delete prod
            target.Delete(prod.ProductID);

            //Assert product deleted
            //called with the correct product
            mock.Verify(m => m.DeleteProduct(prod.ProductID));
        }
    }
}
