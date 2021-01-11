using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop.BLL.BusinessModel;
using shop.DAL;
using shop.DAL.Interfaces;
using shop.DAL.Models;
using shop.Web.ViewModel;

namespace shop.Web.Controllers
{
    public class CartController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private Cart _cart;
        public CartController(IUnitOfWork unitOfWork, Cart cart)
        {
            _unitOfWork = unitOfWork;
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
        public async Task<RedirectToActionResult> AddToCart(int productId, string returnUrl)
        {
            var product = await _unitOfWork.Products.GetProductWithColorAndCategoryInfo(productId);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public async Task<RedirectToActionResult> RemoveFromCart(int productId, string returnUrl)
        {
            var product = await _unitOfWork.Products.SingleOrDefaultAsync(p => p.ProductId == productId);
            if(product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}