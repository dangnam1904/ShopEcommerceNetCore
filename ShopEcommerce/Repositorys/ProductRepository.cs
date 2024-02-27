using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Models.ModelViews;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Repositorys
{
    public class ProductRepository : IProduct
    {
        private readonly DataContext dataConext;

        public ProductRepository(DataContext dataConext)
        {
            this.dataConext = dataConext;
        }
        public void CreateOrUpdate(Product product)
        {
           if(product.IdProduct == 0) {
             dataConext.Products.Add(product);
            }
            else
            {
                dataConext.Products.Update(product);
            }
           dataConext.SaveChanges();
        }

        public void Delete(Product product)
        {
            dataConext.Products.Remove(product);
            dataConext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return dataConext.Products;
        }

        public Product GetProductById(int id)
        {
            return dataConext.Products.FirstOrDefault(x => x.IdProduct == id);
        }

        public ProductView GetProductView(int id)
        {
            var productView = from p in dataConext.Products
                              join g in dataConext.GroupOptions on p.IdProduct equals g.IdProduct
                              join o in dataConext.OptionProducts on g.IdGroup equals o.IdGroup
                              where p.IdProduct == id
                              select new
                              {
                                  Product = p,
                                  GroupOption = g,
                                  OptionProduct = o,
                              };
            return (ProductView)productView;
        }
    }
}
