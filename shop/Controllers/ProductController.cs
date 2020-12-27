using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop.DAL.Interfaces;
using shop.Web.ViewModel;

namespace shop.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 6;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(string category, int page = 1)
        {
            return View(new ProductViewModel
            {
                Products = _repository.Products
                    .Where(p => category == null || p.Category.Name == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? _repository.Products.Count() : 
                        _repository.Products.Count(p => p.Category.Name == category)
                },
                CurrentCategory = category
            }); 
        }
        public IActionResult Details(string returnUrl, int productId, string name)
        {
            return View(new DetailsViewModel
            {
                AvailableColor = _repository.GetColor(name),
                Product = _repository.GetProduct(productId),
                ReturnUrl = returnUrl
            });
        }
    }
}