using Microsoft.EntityFrameworkCore;
using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Repositorys
{
    public class MenuRepository : IRepository<Menu>
    {
        private readonly DataContext dataContext;
        
        public MenuRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void CreateOrUpdate(Menu menu)
        {
            try
            {
                
                if (menu.IdMenu != 0)
                {
                   dataContext.Menu.Update(menu);
                    
                }
                else
                {
                    dataContext.Menu.Add(menu);
                }
                dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Menu _object)
        {
            try
            {
                dataContext.Remove((_object.IdMenu));
                dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public IEnumerable<Menu> GetAll()
        {
           return dataContext.Menu.ToList();
        }
        public Menu GetById(int Id)
        {
            Menu menu = null;
            try
            {
                menu = dataContext.Menu.FirstOrDefault(x => x.IdMenu == Id);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return menu;
        }
    }
}
