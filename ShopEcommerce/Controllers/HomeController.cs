
using Microsoft.AspNetCore.Mvc;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;
using System.Diagnostics;

namespace ShopEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepository<Slide> repositySlide;
        private readonly IRepository<Category> repositoryCategories;
        private readonly IRepository<Page> repositoryPages;
        private readonly IPage repositoryPage;

        public HomeController(IRepository<Slide> repositySlide, IRepository<Category> repositoryCategories,
            IRepository<Page> repositoryPages, IPage repositoryPage)
        {
            this.repositySlide = repositySlide;
            this.repositoryCategories = repositoryCategories;
            this.repositoryPages = repositoryPages;
            this.repositoryPage = repositoryPage;
        }

        public IActionResult Index()
        {
            ViewBag.Slide = repositySlide.GetAll();
            ViewBag.Category = repositoryCategories.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("/MyMenu")]
        public IActionResult Page()
        {
            Page page = repositoryPage.getPageByIdMenu(11);
            return View(page);
        }
    }
}