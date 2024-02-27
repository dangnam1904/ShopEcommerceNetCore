using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Repositorys
{
    public class GroupOptionReopsitory : IGroupOption
    {
        private readonly DataContext dataContext;
        public GroupOptionReopsitory(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void CreateOrUpdate(GroupOption groupOption)
        {
            if (groupOption.IdGroup == 0)
            {
                dataContext.GroupOptions.Add(groupOption);
            }
            else
            {
                dataContext.GroupOptions.Update(groupOption);
            }
            dataContext.SaveChanges();
        }

        public void Detele(GroupOption groupOption)
        {
           dataContext.GroupOptions.Remove(groupOption);
            dataContext.SaveChanges();
        }

        public IEnumerable<GroupOption> GetAllGroups()
        {
            return dataContext.GroupOptions;
        }

        public IEnumerable<GroupOption> GetAllGroupsByIdProdut(int idProduct)
        {
            return dataContext.GroupOptions.Where(x=> x.IdProduct == idProduct);
        }

        public GroupOption GetGroupOptionById(int id)
        {
            return dataContext.GroupOptions.FirstOrDefault(x=>x.IdGroup == id);
        }
    }
}
