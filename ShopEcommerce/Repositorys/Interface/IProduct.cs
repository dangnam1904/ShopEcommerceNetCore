using ShopEcommerce.Models;
using ShopEcommerce.Models.ModelViews;

namespace ShopEcommerce.Repositorys.Interface
{
    public interface IProduct
    {
        public void CreateOrUpdate(Product product);

        public void Delete(Product product);
        public Product GetProductById(int id);
        public IEnumerable<Product> GetAll();
        public ProductView GetProductView(int id);
    }
}
