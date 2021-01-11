using Microsoft.AspNetCore.Mvc;
using shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Components
{
    public class NavigationМenuViewComponent : ViewComponent
    {
        private IUnitOfWork _unitOfWork;
        public NavigationМenuViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_unitOfWork.Categories.GetAllAsync());
        }
    }
}
