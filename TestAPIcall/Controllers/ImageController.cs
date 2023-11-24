using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TestAPIcall.Data;
using TestAPIcall.Models;

namespace TestAPIcall.Controllers
{
    public class ImageController : Controller
    {
        private readonly ApplicatonDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageController(IWebHostEnvironment hostEnvironment, ApplicatonDbContext context)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
   
        }

        // GET: Image
        public async Task<IActionResult> Index()
        {
              return _context.ImageModels != null ? 
                          View(await _context.ImageModels.ToListAsync()) :
                          Problem("Entity set 'ApplicatonDbContext.ImageModels'  is null.");
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ImageModels == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModels
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Title,ImageFile")] ImageModel imageModel)
        {
            //if (ModelState.IsValid)
            //{
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          //  }
            //return View(imageModel);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.ImageModels == null)
            //{
            //    return NotFound();
            //}

            //var imageModel = await _context.ImageModels.FindAsync(id);
            //if (imageModel == null)
            //{
            //    return NotFound();
            //}
            //return View(imageModel);

            return View(_context.ImageModels.Where(a => a.ImageId == id).FirstOrDefault());
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Title,ImageName")] ImageModel imageModel)
        {
            //if (id != imageModel.ImageId)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    try
            //    {

            //        _context.Update(imageModel);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ImageModelExists(imageModel.ImageId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //  return View(imageModel);

            _context.Update(imageModel);
            _context.Entry(imageModel).Property(x => x.ImageName).IsModified = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImageModels == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModels
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImageModels == null)
            {
                return Problem("Entity set 'ApplicatonDbContext.ImageModels'  is null.");
            }
            var imageModel = await _context.ImageModels.FindAsync(id);
            if (imageModel != null)
            {
                _context.ImageModels.Remove(imageModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageModelExists(int id)
        {
          return (_context.ImageModels?.Any(e => e.ImageId == id)).GetValueOrDefault();
        }
    }
}
