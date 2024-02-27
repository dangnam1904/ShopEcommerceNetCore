using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Repositorys
{
    public class PageRepository : IRepository<Page>,IPage
    {
        private readonly DataContext dataContext;
        public PageRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void CreateOrUpdate(Page _object)
        {
            if (_object.IdPage == 0)
            {
                dataContext.Pages.Add(_object);
            }
            else
            {
                dataContext.Pages.Update(_object);
            }
            dataContext.SaveChanges();
        }

        public void Delete(Page _object)
        {
           dataContext.Pages.Remove(_object);
            dataContext.SaveChanges();
        }

        public IEnumerable<Page> GetAll()
        {
         return   dataContext.Pages.ToList();
        }

        public Page GetById(int Id)
        {
           return dataContext.Pages.FirstOrDefault(x=> x.IdMenu ==Id);
        }

        public Page getPageByIdMenu(int id)
        {
            return dataContext.Pages.Where(x => x.IdMenu == id).FirstOrDefault();
        }
    }
}
