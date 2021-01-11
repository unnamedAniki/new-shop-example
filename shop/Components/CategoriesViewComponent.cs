using Microsoft.AspNetCore.Mvc;

using shop.DAL;
using shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IUnitOfWork _unitOfWork;
        public CategoriesViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke(string name)
        {
            return View(_unitOfWork.Categories.Find(p => p.Name == name));
        }
    }
}
