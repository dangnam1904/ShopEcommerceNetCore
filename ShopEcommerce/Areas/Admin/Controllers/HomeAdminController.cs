using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShopEcommerce.Area.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController: Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
