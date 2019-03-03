using Microsoft.EntityFrameworkCore;
using NLog;
using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Project0.Test
{
    public class LocationTest
    {
        [Fact]
        public void TestCheckCanOrderCupcakeTrue()
        {
            // Arrange
            int storeLocationId = 1;
            int customerId = 1;
            int cupcakeId = 1;
            int orderQnty = 5;

            List<Library.Order> orders = new List<Library.Order>
            {
                new Library.Order
                {
                    Id = 1,
                    OrderLocation = 1,
                    OrderCustomer = 1,
                    OrderCupcake = 1,
                    OrderQuantity = 999,
                    OrderTime = DateTime.Now
                }
            };

            // Act and Assert
            Assert.True(Library.Location.CheckCanOrderCupcake(storeLocationId, cupcakeId, orders));
            
            //var recipe = p0Repo.GetRecipe(cupcakeId);
            //var locationInv = p0Repo.GetLocationInv(storeLocationId);
            //if (!Library.Location.CheckOrderFeasible(recipe, locationInv, orderQnty))
            //{
            //    Console.WriteLine("This store does not have enough ingredients to place the requested order.");
            //    return;
            //}
            //if (Library.Customer.CheckCustomerCanOrder(customerId, storeLocationId, orders))
            //{
            //    Console.WriteLine("Customer can't place an order at this store because it hasn't been 2 hours \n" +
            //        "since there last order yet.");
            //    return;
            //}

            //p0Repo.AddCupcakeOrder(storeLocationId, customerId, cupcakeId, orderQnty);
            //int newOrderId = p0Repo.GetLastCupcakeOrderAdded();
            //p0Repo.UpdateLocationInv(storeLocationId, recipe, orderQnty);
            //Console.WriteLine($"Order with id of {newOrderId} successfully created!");


           
        }

        [Fact]
        public void TestCheckCanOrderCupcakeFalse()
        {
            // Arrange
            int storeLocationId = 1;
            int customerId = 1;
            int cupcakeId = 1;
            int orderQnty = 5;

            List<Library.Order> orders = new List<Library.Order>
            {
                new Library.Order
                {
                    Id = 1,
                    OrderLocation = 1,
                    OrderCustomer = 1,
                    OrderCupcake = 1,
                    OrderQuantity = 1000,
                    OrderTime = DateTime.Now
                }
            };

            // Act and Assert
            Assert.False(Library.Location.CheckCanOrderCupcake(storeLocationId, cupcakeId, orders));
        }

        [Fact]
        public void TestCheckOrderFeasibleInvGreaterTrue()
        {
            // Arrange
            int storeLocationId = 1;
            int customerId = 1;
            int cupcakeId = 1;
            int orderQnty = 1;

            Dictionary<int, decimal> recipe = new Dictionary<int, decimal>
            {
                { 1, 1 },
                { 2, 1 },
                { 3, 1 },
                { 4, 1 },
                { 5, 1 },
                { 6, 1 },
                { 7, 1 },
                { 8, 1 },
                { 9, 1 },
                { 10, 1 },
                { 11, 1 },
                { 12, 1 },
                { 13, 1 },
                { 14, 1 },
                { 15, 1 },
                { 16, 1 },
                { 17, 1 },
                { 18, 1 }
            };

            Dictionary<int, decimal> locationInv = new Dictionary<int, decimal>
            {
                { 1, 2 },
                { 2, 2 },
                { 3, 2 },
                { 4, 2 },
                { 5, 2 },
                { 6, 2 },
                { 7, 2 },
                { 8, 2 },
                { 9, 2 },
                { 10, 2 },
                { 11, 2 },
                { 12, 2 },
                { 13, 2 },
                { 14, 2 },
                { 15, 2 },
                { 16, 2 },
                { 17, 2 },
                { 18, 2 }
            };

            // Act and Assert
            Assert.True(Library.Location.CheckOrderFeasible(recipe, locationInv, orderQnty));
        }

        [Fact]
        public void TestCheckOrderFeasibleInvEqualTrue()
        {
            // Arrange
            int storeLocationId = 1;
            int customerId = 1;
            int cupcakeId = 1;
            int orderQnty = 1;

            Dictionary<int, decimal> recipe = new Dictionary<int, decimal>
            {
                { 1, 1 },
                { 2, 1 },
                { 3, 1 },
                { 4, 1 },
                { 5, 1 },
                { 6, 1 },
                { 7, 1 },
                { 8, 1 },
                { 9, 1 },
                { 10, 1 },
                { 11, 1 },
                { 12, 1 },
                { 13, 1 },
                { 14, 1 },
                { 15, 1 },
                { 16, 1 },
                { 17, 1 },
                { 18, 1 }
            };

            Dictionary<int, decimal> locationInv = new Dictionary<int, decimal>
            {
                { 1, 1 },
                { 2, 1 },
                { 3, 1 },
                { 4, 1 },
                { 5, 1 },
                { 6, 1 },
                { 7, 1 },
                { 8, 1 },
                { 9, 1 },
                { 10, 1 },
                { 11, 1 },
                { 12, 1 },
                { 13, 1 },
                { 14, 1 },
                { 15, 1 },
                { 16, 1 },
                { 17, 1 },
                { 18, 1 }
            };

            // Act and Assert
            Assert.True(Library.Location.CheckOrderFeasible(recipe, locationInv, orderQnty));
        }

        [Fact]
        public void TestCheckOrderFeasibleInvLessFalse()
        {
            // Arrange
            int storeLocationId = 1;
            int customerId = 1;
            int cupcakeId = 1;
            int orderQnty = 1;

            Dictionary<int, decimal> recipe = new Dictionary<int, decimal>
            {
                { 1, 1 },
                { 2, 1 },
                { 3, 1 },
                { 4, 1 },
                { 5, 1 },
                { 6, 1 },
                { 7, 1 },
                { 8, 1 },
                { 9, 1 },
                { 10, 1 },
                { 11, 1 },
                { 12, 1 },
                { 13, 1 },
                { 14, 1 },
                { 15, 1 },
                { 16, 1 },
                { 17, 1 },
                { 18, 1 }
            };

            Dictionary<int, decimal> locationInv = new Dictionary<int, decimal>
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
                { 7, 0 },
                { 8, 0 },
                { 9, 0 },
                { 10, 0 },
                { 11, 0 },
                { 12, 0 },
                { 13, 0 },
                { 14, 0 },
                { 15, 0 },
                { 16, 0 },
                { 17, 0 },
                { 18, 0 }
            };

            // Act and Assert
            Assert.False(Library.Location.CheckOrderFeasible(recipe, locationInv, orderQnty));
        }

        

    }
}