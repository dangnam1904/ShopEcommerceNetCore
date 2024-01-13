namespace ShopEcommerce.Repositorys.Interface
{
        public interface IRepository<T>
        {
            public void CreateOrUpdate(T _object);
            public void Delete(T _object);
            public IEnumerable<T> GetAll();
            public T GetById(int Id);
        }
}
