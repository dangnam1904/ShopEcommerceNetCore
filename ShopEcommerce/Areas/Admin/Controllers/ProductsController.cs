using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Models.ModelViews;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProduct repositoryProduct;
        private readonly IGroupOption repositoryGroupOption;
        private readonly IOptionProduct repositoryOptionProduct;
        private readonly IRepository<Category> categoryRepository;

        public ProductsController( IProduct product, IGroupOption groupOption, 
            IOptionProduct optionProduct, IRepository<Category> categoryRepository)
        {
            this.repositoryProduct = product;
            this.repositoryGroupOption = groupOption;
            this.repositoryOptionProduct = optionProduct;
            this.categoryRepository = categoryRepository;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var list = repositoryProduct.GetAll();
            return View(list);
        }

        public IActionResult CreateOrUpdate(int id)
        {
            Product product = null;
            ProductView productView = null;
            ViewData["IdCategory"] = new SelectList(categoryRepository.GetAll(), "IdCategory", "NameCategoty");
            if (id == 0)
            {
                 product= new Product();
                //productView = new ProductView(){
                //    Product = new Product(),
                //    GroupOptions = new List<GroupOption>()
                //    {
                //        new GroupOption()
                //    },
                //    OptionProducts = new List<OptionProduct>()
                //    {
                //        new OptionProduct()
                //    }
                //};
                productView = new ProductView();
            }
            else
            {
                product = repositoryProduct.GetProductById(id);
                productView = repositoryProduct.GetProductView(id);
            }
            return View(productView);
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(ProductView productView)
        {
            if (ModelState.IsValid)
            {
                repositoryProduct.CreateOrUpdate(productView.Product);  
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategory"] = new SelectList(categoryRepository.GetAll(), "IdCategory", "NameCategoty");
            return View(productView);
        }

       
        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var product = repositoryProduct.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            repositoryProduct.Delete(repositoryProduct.GetProductById(id));
            
            return RedirectToAction(nameof(Index));
        }
    }
}
