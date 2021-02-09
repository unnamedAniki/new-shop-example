using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using shop.DAL.Models;
using shop.DAL.Services;
using shop.Web.Resources;

namespace shop.Web.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IColorService _colorService;
        private IMapper _mapper;
        public AdminController(IProductService productService, ICategoryService categoryService, IColorService colorService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _colorService = colorService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            var productResource = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResources>>(products);
            return View(productResource);
        }
        public async Task<ViewResult> Edit(int ProductId)
        {
            var categories = _categoryService.GetCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", categories.FirstOrDefault());
            var colors = _colorService.GetColors();
            ViewBag.Colors = new SelectList(colors, "Id", "Name", colors.FirstOrDefault());
            return View(await _productService.GetProduct(ProductId));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int ProductId, ProductResources receivedProduct)
        {
            var updatedProduct = await _productService.GetProduct(ProductId);
            if (updatedProduct == null)
            {
                TempData["message"] = "Selected product was not found";
                return RedirectToAction("Index");
            }
            var product = _mapper.Map<ProductResources, Product>(receivedProduct);
            if (await _productService.EditProduct(updatedProduct, product))
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