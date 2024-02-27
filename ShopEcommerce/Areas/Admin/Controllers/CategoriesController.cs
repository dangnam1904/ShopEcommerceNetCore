using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;

namespace ShopEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoriesController(IRepository<Category>  repository)
        {
            this._categoryRepository = repository;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            var category = _categoryRepository.GetAll();
              return View(category);           
        }

        // GET: Admin/Categories/Create
        public IActionResult CreateOrUpdate( int id)
        {
            Category category = null;
           if(id == 0)
            {
                category = new Category();
            }
            else
            {
                category= _categoryRepository.GetById(id);
            }
           return View(category);
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(Category category)
        {
            if (ModelState.IsValid)
            {
               _categoryRepository.CreateOrUpdate(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _categoryRepository.Delete(_categoryRepository.GetById(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
