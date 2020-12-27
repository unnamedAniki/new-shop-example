using Microsoft.AspNetCore.Mvc;
using shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Components
{
    public class ColorsViewComponent : ViewComponent
    {
        private IColorRepository _repository;
        public ColorsViewComponent(IColorRepository repository)
        {
            _repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_repository.Colors);
        }
    }
}
