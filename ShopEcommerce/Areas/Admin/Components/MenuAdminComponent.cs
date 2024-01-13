using Microsoft.AspNetCore.Mvc;

namespace ShopEcommerce.Areas.Admin.Components
{
    [ViewComponent(Name = "MenuAdmin")]
    public class MenuAdminComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
