using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using shop.DAL.Models;
using shop.DAL.Services;

namespace shop.Web.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(_productService.GetProducts());
        }
        public ViewResult Edit(int ProductId)
        {
            return View(_productService.GetProduct(ProductId));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (await _productService.EditProduct(product))
            {
                TempData["message"] = "Selected product was edited";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            if (await _productService.DeleteProduct(product))
            {
                TempData["message"] = "Selected product was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}