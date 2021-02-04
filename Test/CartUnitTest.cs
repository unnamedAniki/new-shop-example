using System;
using Xunit;
using Moq;
using shop.DAL.Services;
using shop.BLL.BusinessModel;
using shop.DAL.Models;
using shop.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace shop.Tests
{
    public class CartUnitTest
    {
        [Fact]
        public void Cannot_Checkout_Empty_Car()
        {
            Mock<IOrderService> mock = new Mock<IOrderService>();
            Cart cart = new Cart();
            Order order = new Order();
            OrderController target = new OrderController(cart, mock.Object);
            ViewResult result = target.Checkout(order).Result as ViewResult;
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            Assert.False(result.ViewData.ModelState.IsValid);
        }
        [Fact]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            Mock<IOrderService> mock = new Mock<IOrderService>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            OrderController target = new OrderController(cart, mock.Object);
            target.ModelState.AddModelError("error", "error");
            ViewResult result = target.Checkout(new Order()).Result as ViewResult;
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            Assert.False(result.ViewData.ModelState.IsValid);
        }
        [Fact]
        public void Can_Checkout_And_Sumbit_Order()
        {
            Mock<IOrderService> mock = new Mock<IOrderService>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            OrderController target = new OrderController(cart, mock.Object);
            RedirectToActionResult result = target.Checkout(new Order()).Result as RedirectToActionResult;
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);
            Assert.Equal("Completed", result.ActionName);
        }
    }
}
