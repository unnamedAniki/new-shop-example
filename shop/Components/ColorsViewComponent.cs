using Microsoft.AspNetCore.Mvc;

using shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Components
{
    public class ColorsViewComponent : ViewComponent
    {
        private IUnitOfWork _unitOfWork;
        public ColorsViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke()
        {
            return View(Task.FromResult(_unitOfWork.Colors.GetColors()));
        }
    }
}
