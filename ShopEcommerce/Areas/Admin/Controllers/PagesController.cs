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
    public class PagesController : Controller
    {
        private readonly IRepository<Page> _repositoryPage;
        private readonly IRepository<Menu> _repositoryMenu;


        public PagesController( IRepository<Page> repository, IRepository<Menu> repositoryMenu)
        {
            this._repositoryPage = repository;
            this._repositoryMenu = repositoryMenu;
        }

        // GET: Admin/Pages
        public async Task<IActionResult> Index()
        {
           return View(_repositoryPage.GetAll());
        }

        public IActionResult CreateOrUpdate(int id)
        {
            Page page = null;
            if (id == 0)
            {
                page = new Page();
            }
            else
            {
                page= _repositoryPage.GetById(id);
            }
            ViewData["IdMenu"] = new SelectList(_repositoryMenu.GetAll(), "IdMenu", "NameMenu");
            return View(page);
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate( Page page)
        {
            if (ModelState.IsValid)
            {
               _repositoryPage.CreateOrUpdate(page);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMenu"] = new SelectList(_repositoryMenu.GetAll(), "IdMenu", "NameMenu");
            return View(page);
        }

        
        // GET: Admin/Pages/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var page = _repositoryPage.GetById(id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var page = _repositoryPage.GetById(id);
            if (page != null)
            {
                _repositoryPage.Delete(page);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
