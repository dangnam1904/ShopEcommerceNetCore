using ShopEcommerce.Models;
namespace ShopEcommerce.Data;

public class InitData
{
    public static void Seed( IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope() ) 
        {
            var dataContext= serviceScope.ServiceProvider.GetService<DataContext>();
            if(!dataContext.Roles.Any())
            {
                dataContext.Roles.AddRange
                    (new Role()
                    {
                        NameRole = "Admin"
                    },
                    new Role()
                    {
                        NameRole = "User"
                    });
                dataContext.SaveChanges();
            }
            if (!dataContext.Users.Any())
            {
                dataContext.Users.AddRange(
                    new User()
                    {
                        FullName = "Đặng Văn Nam",
                        UserName = "dangnam",
                        NumberPhone = "0394625591",
                        Address = "Con Cuông",
                        Email = "dangnam1904yk@gmail.com",
                        Password = "dangnam",
                        IdRole = 2
                    },
                    new User()
                    {
                        FullName = "Đặng Văn Nam",
                        UserName = "admin",
                        NumberPhone = "0394625591",
                        Address = "Con Cuông",
                        Email = "admin@gmail.com",
                        Password = "dangnam",
                        IdRole = 1
                    });
                dataContext.SaveChanges() ;
            }
        }
    }
}
