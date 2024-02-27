using Humanizer.Localisation.TimeToClockNotation;
using ShopEcommerce.Models;

namespace ShopEcommerce.Repositorys.Interface
{
    public interface IOptionProduct
    {
        public void CreateOrUpdate( OptionProduct product );
        public void Delete( OptionProduct product );
        public OptionProduct GetOptionProductById( int id );
        public IEnumerable<OptionProduct> GetAllByIdGroup(int IdGroup);
    }
}
