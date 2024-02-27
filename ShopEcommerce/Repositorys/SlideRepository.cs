using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Repositorys
{
    public class SlideRepository : IRepository<Slide>
    {
        private readonly DataContext dataContext;

        public SlideRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void CreateOrUpdate(Slide _object)
        {
            if( _object.Id == 0 )
            {
                dataContext.Slides.Add( _object );
            }
            else
            {
                dataContext.Slides.Update( _object );
            }
            dataContext.SaveChanges();
        }

        public void Delete(Slide _object)
        {
           dataContext
                .Remove( _object );
            dataContext.SaveChanges();

        }

        public IEnumerable<Slide> GetAll()
        {
            try
            {
                return dataContext.Slides.ToList();
            }catch ( Exception ex )
            {
                throw;
            }
         
        }

        public Slide GetById(int Id)
        {
            return dataContext.Slides.FirstOrDefault(x => x.Id == Id);
        }
    }
}
