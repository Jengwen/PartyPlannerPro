using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartyPlannerPro.Data;
using PartyPlannerPro.Models;

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
            return View();
        }

        // POST: VendorCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] VendorCategory vendorCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendorCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendorCategory);
        }

        // GET: VendorCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorCategory = await _context.VendorCatergories.FindAsync(id);
            if (vendorCategory == null)
            {
                return NotFound();
            }
            return View(vendorCategory);
        }

        // POST: VendorCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName")] VendorCategory vendorCategory)
        {
            if (id != vendorCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendorCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorCategoryExists(vendorCategory.Id))
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
            return View(vendorCategory);
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
