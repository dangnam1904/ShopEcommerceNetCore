using ShopEcommerce.Models;
using ShopEcommerce.Repositorys;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Services
{
    public class MenuService
    {
        private readonly IRepository<Menu>  repository  ;

        public MenuService( IRepository<Menu> repository)
        {
            this.repository = repository;
        }
        public void CreateOrUpdateMenu(Menu menu)
        {
            repository.CreateOrUpdate(menu);
        }
        public Menu getMenuById( int id)
        {
            try
            {
                return repository.GetById(id);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteMenu(Menu menu)
        {
            repository.Delete(menu);
        }
        public IEnumerable<Menu> GetAll()
        {
            return repository.GetAll();
        }
        
    }
}
