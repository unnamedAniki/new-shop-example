using Microsoft.AspNetCore.Mvc;
using shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private ICategoryRepository _repository;
        public CategoriesViewComponent(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public IViewComponentResult Invoke(string name)
        {
            return View(_repository.Categories.FirstOrDefault(p => p.Name == name));
        }
    }
}
