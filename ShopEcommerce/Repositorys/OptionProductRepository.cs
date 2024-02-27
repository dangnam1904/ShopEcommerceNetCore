using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Repositorys
{
    public class OptionProductRepository : IOptionProduct
    {
        private DataContext context;
        public OptionProductRepository(DataContext context)
        {
            this.context = context;
        }
        public void CreateOrUpdate(OptionProduct OpProduct)
        {
            if (OpProduct.IdGroup == 0)
            {
                context.OptionProducts.Add(OpProduct);
            }
            else
            {
                context.OptionProducts.Update(OpProduct);
            }
            context.SaveChanges();
        }

        public void Delete(OptionProduct OpProduct)
        {
           context.OptionProducts.Remove(OpProduct);
            context.SaveChanges();
        }

        public IEnumerable<OptionProduct> GetAllByIdGroup(int IdGroup)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OptionProduct> GetAllByIdProduct( int IdGroup)
        {
            var data = from o in context.OptionProducts
                       join g in context.GroupOptions on o.IdGroup equals g.IdGroup
                       where g.IdGroup == IdGroup
                       select new
                       {
                           GroupOption = g,
                           OptionProduct = o
                       };
            return (IEnumerable<OptionProduct>)data;
        }

        public OptionProduct GetOptionProductById(int id)
        {
           return context.OptionProducts.FirstOrDefault(x=>x.IdOption==id);
        }
    }
}
