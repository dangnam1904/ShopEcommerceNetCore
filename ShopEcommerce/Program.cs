using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys;
using ShopEcommerce.Repositorys.Interface;
using ShopEcommerce.Services;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("Con");

builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(connection);
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IRepository<Menu>, MenuRepository>();
builder.Services.AddScoped<IRepository<Slide>, SlideRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Page>, PageRepository>();
builder.Services.AddScoped<IPage, PageRepository>();
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<IGroupOption, GroupOptionReopsitory>();
builder.Services.AddScoped<IOptionProduct, OptionProductRepository>();



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=HomeAdmin}/{action=Index}/{id?}"
    );
});
InitData.Seed(app);
app.MapControllerRoute(
    name: "default",

    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
