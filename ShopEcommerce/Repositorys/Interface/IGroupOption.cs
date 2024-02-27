using ShopEcommerce.Models;

namespace ShopEcommerce.Repositorys.Interface
{
    public interface IGroupOption
    {
        public void CreateOrUpdate( GroupOption groupOption );
        public void Detele( GroupOption groupOption );
        public GroupOption GetGroupOptionById( int id );
        public IEnumerable<GroupOption> GetAllGroups();
        public IEnumerable<GroupOption> GetAllGroupsByIdProdut(int idProduct);

    }
}
