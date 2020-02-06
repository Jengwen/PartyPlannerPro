using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartyPlannerPro.Data;
using PartyPlannerPro.Models;
using PartyPlannerPro.Models.ViewModels;

namespace PartyPlannerPro.Controllers
{
    public class VendorCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VendorCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.VendorCatergories.ToListAsync());
        }

        // GET: VendorCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorCategory = await _context.VendorCatergories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorCategory == null)
            {
                return NotFound();
            }

            return View(vendorCategory);
        }

        // GET: VendorCategories/Create
        public IActionResult Create()
        {
            //instantiate view model for image uploader
            ImageUploadViewModel vm = new ImageUploadViewModel();

            return View(vm);
        }

        // POST: VendorCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImageUploadViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // check to see if image file exists
                if (vm.ImageFile != null)
                {
                    // convert image into byte array
                    using (var memoryStream = new MemoryStream())
                    {
                        await vm.ImageFile.CopyToAsync(memoryStream);
                        vm.vendorCategory.CategoryImage = memoryStream.ToArray();
                    }
                };
                _context.Add(vm.vendorCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {

            }
            return View(vm);
        }

        // GET: VendorCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //instantiate view model for image uploader
           EditImageVCViewModel evm = new EditImageVCViewModel();

            if (id == null)
            {
                return NotFound();
            }

            evm.vendorCategory = await _context.VendorCatergories.FindAsync(id);
            if (evm.vendorCategory == null)
            {
                return NotFound();
            }
            return View(evm);
        }

        // POST: VendorCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditImageVCViewModel evm)
        {

            if (id != evm.vendorCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // check to see if image file exists
                if (evm.ImageFile != null)
                {
                    // convert image into byte array
                    using (var memoryStream = new MemoryStream())
                    {
                        await evm.ImageFile.CopyToAsync(memoryStream);
                        evm.vendorCategory.CategoryImage = memoryStream.ToArray();
                    }
                };
                try
                {
                    _context.Update(evm.vendorCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorCategoryExists(evm.vendorCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(evm);
        }

        // GET: VendorCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorCategory = await _context.VendorCatergories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorCategory == null)
            {
                return NotFound();
            }

            return View(vendorCategory);
        }

        // POST: VendorCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendorCategory = await _context.VendorCatergories.FindAsync(id);
            _context.VendorCatergories.Remove(vendorCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorCategoryExists(int id)
        {
            return _context.VendorCatergories.Any(e => e.Id == id);
        }
    }
}
