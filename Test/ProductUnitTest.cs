using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using shop.DAL.Models;
using shop.DAL.Services;
using shop.Web.Controllers;
using shop.Web.Resources;

using System;
using System.Collections.Generic;
using Xunit;

namespace shop.Test
{
    public class ProductUnitTest
    {
        private T GetViewModel<T>(IActionResult result) where T : class => (result as ViewResult)?.ViewData.Model as T;
        [Fact]
        public void Can_Edit_Product()
        {
            Mock<IProductService> mock = new Mock<IProductService>();
            Mock<ICategoryService> mock2 = new Mock<ICategoryService>();
            Mock<IColorService> mock3 = new Mock<IColorService>();
            mock.Setup(m => m.GetProduct(1).Result).Returns(new Product
            {
                ProductId = 1,
                Name = "First"
            });
            AdminController target = new AdminController(mock.Object, mock2.Object, mock3.Object, null);
            var p1 = target.Edit(1).Result.ViewData.Model as Product;
            var p2 = target.Edit(2).Result.ViewData.Model as Product;
            Assert.Equal(1, p1.ProductId);
            Assert.Null(p2);
        }
        [Fact]
        public void Cannot_Edit_Nonexistent_Product()
        {
            Mock<IProductService> mock = new Mock<IProductService>();
            Mock<ICategoryService> mock2 = new Mock<ICategoryService>();
            Mock<IColorService> mock3 = new Mock<IColorService>();
            mock.Setup(m => m.GetProducts().Result).Returns(new Product[]
            {
                new Product { ProductId = 1, Name = "First" },
                new Product { ProductId = 2, Name = "Second" },
                new Product { ProductId = 2, Name = "Third"}
            });
            AdminController target = new AdminController(mock.Object, mock2.Object, mock3.Object, null);
            Product result = GetViewModel<Product>(target.Edit(4).Result);
            Assert.Null(result);
        }
    }
}
