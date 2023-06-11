using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using DataAccessLayer.Repositories.FakeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.FakeRepos;

namespace UnitTesting
{
    [TestClass]
    public class OrderManagmentTest
    {
        private FakeOrderRepo orderRepo;
        private OrderManager orderManager;

        [TestInitialize]
        public void SetUp()
        {
            orderRepo = new FakeOrderRepo();
            orderManager = new OrderManager(orderRepo);
        }

        [TestMethod]
        public void Create_Order_CallsOrderRepoCreate()
        {
            // Arrange
            Order order = new Order();

            // Act
            orderManager.Create(order);

            // Assert
            List<Order> orders = orderRepo.GetAll();
            CollectionAssert.Contains(orders, order);
        }

        [TestMethod]
        public void Delete_OrderId_CallsOrderRepoDelete()
        {
            // Arrange
            int orderId = 4;
            Order order = new Order { Id = orderId };
            orderManager.Create(order);

            // Act
            orderManager.Delete(orderId);

            // Assert
            List<Order> orders = orderRepo.GetAll();
            CollectionAssert.DoesNotContain(orders, order);
        }

        [TestMethod]
        public void GetAll_ReturnsAllOrders()
        {
            // Arrange
            Order order1 = new Order { Id = 4 };
            Order order2 = new Order { Id = 5 };
            orderRepo.Create(order1);
            orderRepo.Create(order2);

            // Act
            List<Order> orders = orderManager.GetAll();

            // Assert
            CollectionAssert.Contains(orders, order1);
            CollectionAssert.Contains(orders, order2);
        }


        [TestMethod]
        public void GetByID_OrderId_ReturnsOrder()
        {
            // Arrange
            int OrderIDToGet = 1;
            Order expectedOrder = orderManager.GetByID(OrderIDToGet);

            // Act
            Order order = orderManager.GetByID(OrderIDToGet);

            // Assert
            Assert.IsNotNull(order);
            Assert.AreEqual(expectedOrder, order);
        }


        [TestMethod]
        public void UpdateAsFulfilled_Order_CallsOrderRepoUpdateAsFulfilled()
        {
            // Arrange
            Order order = new Order { Id = 4, Status = "new" };
            orderManager.Create(order);

            // Act
            orderManager.UpdateAsFulFilled(order);

            // Assert
            Order updatedOrder = orderManager.GetByID(4);
            Assert.AreEqual("fulfilled", updatedOrder.Status);
        }


        [TestMethod]
        public void CalculateTotalPrice_WithoutPremiumClient_ReturnsTotalPrice()
        {
            // Arrange
            Client client = new Client { Subscribtion = "normal" };
            Product product1 = new Product { Price = 10 };
            Product product2 = new Product { Price = 15 };
            Order order = new Order { Client = client, Products = new List<Product> { product1, product2 } };
            double expectedTotalPrice = product1.Price + product2.Price;

            // Act
            double result = orderManager.CalculateTotalPrice(order);

            // Assert
            Assert.AreEqual(expectedTotalPrice, result);
        }

        [TestMethod]
        public void CalculateTotalPrice_WithPremiumClient_ReturnsTotalPriceWithDiscount()
        {
            // Arrange
            Client client = new Client { Subscribtion = "premium" };
            Product product1 = new Product { Price = 10 };
            Product product2 = new Product { Price = 15 };
            Order order = new Order { Client = client, Products = new List<Product> { product1, product2 } };
            double expectedTotalPrice = (product1.Price + product2.Price) - (product1.Price + product2.Price) * 0.15;

            // Act
            double result = orderManager.CalculateTotalPrice(order);

            // Assert
            Assert.AreEqual(expectedTotalPrice, result);
        }


        [TestMethod]
        public void GetOrderByClient()
        {
            // Arrange
            Client client = new Client { Id = 5 };
            Order expectedOrder = new Order { Id = 5, Client = client };
            orderManager.Create(expectedOrder);

            // Act
            Order result = orderManager.GetOrderByClient(client);

            // Assert
            Assert.AreEqual(expectedOrder, result);
        }


        [TestMethod]
        public void FinishOrder_Order_CallsOrderRepoFinishOrder()
        {
            // Arrange
            Order order = new Order { Id = 4, Status = "new" };
            orderRepo.Create(order);

            // Act
            orderManager.FinishOrder(order);

            // Assert
            Order updatedOrder = orderRepo.GetById(4);
            Assert.AreEqual("finished", updatedOrder.Status);
        }


















    }
}
