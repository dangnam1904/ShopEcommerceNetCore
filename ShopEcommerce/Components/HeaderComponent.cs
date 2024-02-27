using Microsoft.AspNetCore.Mvc;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Components
{
    [ViewComponent(Name = "Header")]
    public class HeaderComponent : ViewComponent
    {
        private readonly IRepository<Menu> repository;
        public HeaderComponent(IRepository<Menu> repository)
        {
            this.repository = repository;
         }
        public IViewComponentResult Invoke()
        {
            var ss = repository.GetAll().Where(x => x.IsActive == true)
                .OrderBy(x => x.MenuOrder);
            return View(ss);
        }
    }
}
