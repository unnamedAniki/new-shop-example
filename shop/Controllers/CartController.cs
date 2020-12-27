using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop.BLL.BusinessModel;
using shop.DAL.Interfaces;
using shop.DAL.Models;
using shop.Web.ViewModel;

namespace shop.Web.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        private Cart _cart;
        public CartController(IProductRepository repository, Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            var product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if(product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}