using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Repositorys
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DataContext dataContext;
        public CategoryRepository( DataContext dataContext) 
        {
            this.dataContext = dataContext;

        }
        public void CreateOrUpdate(Category _object)
        {
            if(_object.IdCategory == 0)
            {
                dataContext.Categories.Add(_object);
            }
            else
            {
                dataContext.Categories.Update(_object);
            }
            dataContext.SaveChanges();
        }

        public void Delete(Category _object)
        {
            dataContext.Categories.Remove(_object);
            dataContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
          return dataContext.Categories.ToList();
        }

        public Category GetById(int Id)
        {
            return dataContext.Categories.FirstOrDefault(x => x.IdCategory == Id) ?? throw null;
        }
    }
}
