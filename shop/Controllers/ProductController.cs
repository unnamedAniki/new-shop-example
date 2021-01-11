using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using shop.DAL;
using shop.DAL.Interfaces;
using shop.Web.ViewModel;

namespace shop.Web.Controllers
{
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public int PageSize = 6;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string category, int page = 1)
        {
            return View(new ProductViewModel
            {
                Products = _unitOfWork.Products.Find(p => category == null || p.Category.Name == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? _unitOfWork.Products.Count() :
                        _unitOfWork.Products.Count(p => p.Category.Name == category)
                },
                CurrentCategory = category
            }); 
        }
        public async Task<IActionResult> Details(string returnUrl, int productId, string name)
        {
            return View(new DetailsViewModel
            {
                AvailableColor = await _unitOfWork.Products.GetColor(name),
                Product = await _unitOfWork.Products.GetProduct(productId),
                ReturnUrl = returnUrl
            });
        }
    }
}