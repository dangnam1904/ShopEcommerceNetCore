using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys;
using ShopEcommerce.Repositorys.Interface;
using ShopEcommerce.Services;

namespace ShopEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenusController : Controller
    {
        private readonly IRepository<Menu> repository;
        public MenusController(IRepository<Menu> repository)
        {
            this.repository = repository;
        }

        // GET: Admin/Menus
        public async Task<IActionResult> Index()
        {
            var listMenu = repository.GetAll();
            return listMenu != null ?
                        View(listMenu) :
                        Problem("Entity set 'DataContext.Menu'  is null.");
        }

        // GET: Admin/Menus/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = repository.GetById(id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Admin/Menus/CreateOrUpdate
        public IActionResult CreateOrUpdate(int id)
        {
            Menu menu = repository.GetById(id);
            if (menu == null)
            {
                menu = new Menu();
            }
            ViewBag.Menu = new SelectList(repository.GetAll().OrderBy(x=> x.NameMenu), "IdMenu", "NameMenu");
            return View(menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate( Menu menu)
        {
            if (ModelState.IsValid)
            {
                repository.CreateOrUpdate(menu);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Menu = new SelectList(repository.GetAll().OrderBy(x => x.NameMenu), "IdMenu", "NameMenu");
            return View(menu);
        }


        // GET: Admin/Menus/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = repository.GetById(id);
            if (menu != null)
            {
                repository.Delete(menu);    
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = repository.GetById(id);
            if (menu != null)
            {
                repository.Delete(menu);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
