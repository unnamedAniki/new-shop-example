using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shop.DAL.Interfaces;
namespace shop.Web.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository _repository;
        public AdminController(IProductRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.AdminProducts);
        }
        public ViewResult Edit(int ProductId)
        {
            return View(_repository.AdminProducts.FirstOrDefault(p => p.ProductId == ProductId));
        }
        [HttpPost]
        public IActionResult Delete(int ProductId)
        {
            if (_repository.DeleteProduct(ProductId))
            {
                TempData["message"] = "Selected product was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}