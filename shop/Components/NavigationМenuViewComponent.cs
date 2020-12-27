using Microsoft.AspNetCore.Mvc;
using shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Components
{
    public class NavigationМenuViewComponent : ViewComponent
    {
        private ICategoryRepository _repository;
        public NavigationМenuViewComponent(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Categories.ToList());
        }
    }
}
