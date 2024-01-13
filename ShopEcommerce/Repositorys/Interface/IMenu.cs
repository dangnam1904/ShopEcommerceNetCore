using ShopEcommerce.Models;

namespace ShopEcommerce.Repositorys.Interface
{
    public interface IMenu
    {
        public void CreateOrUpdate(Menu menu);
        public void DeleteMenu(int id_menu);
        public IEnumerable<Menu> GetAll();
        public Menu GetMenuById(int id_menu);

    }
}
