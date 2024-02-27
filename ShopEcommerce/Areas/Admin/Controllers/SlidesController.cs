using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShopEcommerce.Data;
using ShopEcommerce.Models;
using ShopEcommerce.Repositorys.Interface;
using ShopEcommerce.Until;

namespace ShopEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidesController : Controller
    {
        private readonly IRepository<Slide> slideRepository;
        private string pathImage = "slider";

        public SlidesController(IRepository<Slide> repository)
        {
           slideRepository = repository;
        }

        // GET: Admin/Slides
        public async Task<IActionResult> Index()
        {
            return View(slideRepository.GetAll());
        }

        // GET: Admin/Slides/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var slide = slideRepository.GetById(id);
            return View(slide);
        }

        // GET: Admin/Slides/Create
        public IActionResult CreateOrUpdate(int id)
        {
            Slide slide = null;
            if (id == 0)
            {
                ViewData["Title"] = "Create";
              slide  = new Slide();
            }
            else
            {
                ViewData["Title"] = "Update";
                slide =slideRepository.GetById(id);
            }
            return View( slide);
        }

        // POST: Admin/Slides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(Slide slide)
        {
            if (ModelState.IsValid)
            {
                if (slide.Id == 0) //add
                {
                    if (slide.ImageFile != null)
                    {
                        slide.NameImg = Functions.saveSingleImage(slide.ImageFile, pathImage);
                    }
                }
                else //update
                {
                    Slide oldeSlide = slideRepository.GetById(slide.Id);
                    if (slide.ImageFile != null)
                    {
                        Functions.deleteSingleImage(oldeSlide.NameImg, pathImage);
                        slide.NameImg = Functions.saveSingleImage(slide.ImageFile, pathImage);
                    }
                    else
                    {
                        slide.NameImg = oldeSlide.NameImg;
                    }
                }
                slideRepository.CreateOrUpdate(slide);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(slide);
            }
        }
        // GET: Admin/Slides/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Slide slide = slideRepository.GetById(id);

            return View(slide);
        }

        // POST: Admin/Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Slide slide=slideRepository.GetById(id);
            slideRepository.Delete(slide);
            Functions.deleteSingleImage(slide.NameImg, pathImage);
            return RedirectToAction(nameof(Index));
        }

    }
}
