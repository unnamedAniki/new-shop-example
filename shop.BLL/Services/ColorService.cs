using shop.DAL;
using shop.DAL.Models;
using shop.BLL.Interfaces.Services;

using System;
using System.Collections.Generic;
using System.Text;

namespace shop.BLL.Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ColorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Color> GetColors() => _unitOfWork.Colors.GetColors().Result;
    }
}
