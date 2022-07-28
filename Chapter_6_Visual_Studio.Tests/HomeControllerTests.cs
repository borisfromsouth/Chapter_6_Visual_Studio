using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Chapter_6_Visual_Studio.Controllers;
using Chapter_6_Visual_Studio.Models;
using Xunit;
using Moq;

namespace Chapter_6_Visual_Studio.Tests
{
    public class HomeControllerTests
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }
            public void AddProduct(Product p)
            {
                // Ничего не делать - для теста не требуется
            }
        }

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModellsComplete(Product[] products)
        {
            //Организация
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);  // берет все элементы m.Products и из них берет только те что находятся в products
            var controller = new HomeController { Repository = mock.Object };
            //controller.Repository = new ModelCompleteFakeRepository{ Products = products};

            //Действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Утверждение
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        class PropertyOnceFakeRepository : IRepository
        {
            public int PropertyCounter { get; set; } = 0;
            public IEnumerable<Product> Products {
                get {
                    PropertyCounter++;
                    return new[] { new Product { Name = "P1", Price = 100 } };
                }
            }

            public void AddProduct(Product p)
            {
                // Ничего не делать - для теста не требуется
            }
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            //Организация
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(new[] { new Product { Name = "P1", Price = 100} });// берет все элементы m.Products и из них берет только конкретный элемент Product(Name = "P1", Price = 100)
            var controller = new HomeController { Repository = mock.Object }; //mock.Object хранит выборку
            //var repo = new PropertyOnceFakeRepository();
            //var controller = new HomeController { Repository = repo };

            //Действие
            var result = controller.Index();

            //Утверждение
            mock.VerifyGet(m => m.Products, Times.Once);
            //Assert.Equal(1, repo.PropertyCounter);
        }
    }
}
