using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop.BLL.BusinessModel;
using shop.DAL.Interfaces;
using shop.DAL.Models;

namespace shop.Web.Controllers
{
    public class OrderController : Controller
    {
        private Cart _cart;
        private IOrderRepository _repository;
        public OrderController(Cart cart, IOrderRepository repository)
        {
            _cart = cart;
            _repository = repository;
        }
        public IActionResult List() => View(_repository.Orders.Where(p => p.Shipped == false));
        [HttpPost]
        public IActionResult MarkShipped(int OrderId)
        {
            Order order = _repository.Orders.FirstOrDefault(p => p.OrderId == OrderId);
            if(order != null)
            {
                order.Shipped = true;
                _repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!_cart.Lines.Any())
            {
                ModelState.AddModelError("", "Your cart is empty");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}