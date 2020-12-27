using shop.BLL.BusinessModel;

namespace shop.Web.ViewModel
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}