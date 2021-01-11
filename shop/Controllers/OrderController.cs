using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop.BLL.BusinessModel;
using shop.DAL;
using shop.DAL.Interfaces;
using shop.DAL.Models;
using shop.DAL.Services;

namespace shop.Web.Controllers
{
    public class OrderController : Controller
    {
        private Cart _cart;
        private IOrderService _orderService;
        public OrderController(Cart cart, IOrderService orderService)
        {
            _cart = cart;
            _orderService = orderService;
        }
        public IActionResult List() => View( _orderService.GetOrderByShipped(false));
        [HttpPost]
        public async Task<IActionResult> MarkShipped(int OrderId)
        {
            Order order = await _orderService.GetOrder(OrderId);
            if(order != null)
            {
                order.Shipped = true;
                await _orderService.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            if (!_cart.Lines.Any())
            {
                ModelState.AddModelError("", "Your cart is empty");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                await _orderService.SaveOrder(order);
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