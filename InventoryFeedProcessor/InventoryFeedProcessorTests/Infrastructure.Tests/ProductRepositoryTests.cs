using InventoryFeedProcessor.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace InventoryFeedProcessorTests.Infrastructure.Tests
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void GetALLShouldReturnTotalAllProductsFromDB()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ProductContext>()
  .UseInMemoryDatabase(databaseName: "EmployeeDataBase")
  .Options;
            using (var context = new ProductContext(options))
            {
                context.Products.Add(new Product
                {
                    Id = 1,
                    Categories = new List<string> { "cat1_1", "cat1_2" },
                    Title = "Test1",
                    TwitterHandle = "@test1"
                });

                context.Products.Add(new Product
                {
                    Id = 2,
                    Categories = new List<string> { "cat2_1", "cat2_2" },
                    Title = "Test2",
                    TwitterHandle = "@test2"
                });

                context.Products.Add(new Product
                {
                    Id = 3,
                    Categories = new List<string> { "cat3_1", "cat3_2" },
                    Title = "Test3",
                    TwitterHandle = "@test3"
                });

                context.Products.Add(new Product
                {
                    Id = 4,
                    Categories = new List<string> { "cat4_1", "cat4_2" },
                    Title = "Test4",
                    TwitterHandle = "@test4"
                });
                context.SaveChanges();
                var productRepository = new ProductRepository(context);
                
                //Act
                List<Product> products = productRepository.GetAll().ToList();

                //Assert
                Assert.Equal(4, products.Count);
            }
        }
        [Fact]
        public void RemoveShouldRemoveThatItemFromDB()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ProductContext>()
  .UseInMemoryDatabase(databaseName: "EmployeeDataBase")
  .Options;
            using (var context = new ProductContext(options))
            {
                var productRepository = new ProductRepository(context);
                var product = productRepository.GetProductById(1);

                //Act
                productRepository.Remove(product);
                context.SaveChanges();

                //Assert
                var prodCollection = productRepository.GetAll();
                Assert.Equal(3, prodCollection.ToList().Count);
            }
        }
    }
}
