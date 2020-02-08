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
    public class VenuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VenuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Venues
        public async Task<IActionResult> Index(string citySearch, int guests)
        {
            List<Venue> venues = await _context.Venues.ToListAsync();

// search by city input
            if (citySearch != null)
            {
                venues = venues.Where(venue => venue.City != null && venue.City.ToString().Contains(citySearch, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            //search by number of guests show only venues where maxCapacity is >= input #
            else if(guests != null)
            {
                venues = venues.Where(venue => venue.MaxCapacity != null && venue.MaxCapacity >= guests).ToList();
            }
            return View(venues);
        }

        // GET: Venues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues
                .Include(v => v.Events)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // GET: Venues/Create
        public IActionResult Create()
        {
            //instantiate view model for image uploader
            UploadVenueViewModel vm = new UploadVenueViewModel();

            return View(vm);
        }

        // POST: Venues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UploadVenueViewModel vm)
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
                        vm.venue.Image = memoryStream.ToArray();
                    }
                };
                _context.Add(vm.venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Venues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //instantiate view model for image uploader
           EditVenueViewModel evm = new EditVenueViewModel();

            if (id == null)
            {
                return NotFound();
            }

           evm.venue = await _context.Venues.FindAsync(id);
            if (evm.venue == null)
            {
                return NotFound();
            }
            return View(evm);
        }

        // POST: Venues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditVenueViewModel evm)
        {
            if (id != evm.venue.Id)
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
                        evm.venue.Image = memoryStream.ToArray();
                    }
                };
                try
                {
                    _context.Update(evm.venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueExists(evm.venue.Id))
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

        // GET: Venues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenueExists(int id)
        {
            return _context.Venues.Any(e => e.Id == id);
        }
    }
}
