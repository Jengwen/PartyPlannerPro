using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartyPlannerPro.Data;
using PartyPlannerPro.Models;
using PartyPlannerPro.Models.ViewModels;

namespace PartyPlannerPro.Controllers
{
    public class EventsController : Controller
    {
        // Private field to store user manager
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Private method to get current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Events
        public async Task<IActionResult> Index()
        {
            //get logged in user
            var user = await GetCurrentUserAsync();

            //return events for only logged in user with customer name and venue name, orber by date and only events that have not occurred

            var applicationDbContext = _context.Events.Where(e => e.User == user).Include(e => e.Customer).Include(e =>e.Venue)
                                .Where(d => d.EventDate > DateTime.Today)
                                .OrderBy(o => o.EventDate);
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.User).Include(e => e.Customer).Include(e => e.Venue).Include(e =>e.EventVendors)
                .ThenInclude(ev => ev.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public async Task<IActionResult> Create()
        {
            //instantiaite view model
            CreateEventViewModel vm = new CreateEventViewModel();


            //set up drop down to display and select venue names

            vm.Venues = _context.Venues.Select(v => new SelectListItem
            {
                Value = v.Id.ToString(),
                Text = v.VenueName
            }).ToList();
            vm.Venues.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose a venue"
            });
            vm.Customers = _context.Customers.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.FirstName +" " + c.LastName 
            }).ToList();
            vm.Customers.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose a customer"
            });

            return View(vm);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventViewModel vm)
        {
            ModelState.Remove("Event.ApplicationUserId");

            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();

                vm.Event.ApplicationUserId = user.Id;

                _context.Add(vm.Event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { vm.Event.Id });
            }
            return View(vm);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //instantiaite view model
            EditEventViewModel vm = new EditEventViewModel();

            if (id == null)
            {
                return NotFound();
            }

           vm.Event = await _context.Events.FindAsync(id);
            if (vm.Event == null)
            {
                return NotFound();
            }
            //set up drop down to display and select venue names

            vm.Venues = _context.Venues.Select(v => new SelectListItem
            {
                Value = v.Id.ToString(),
                Text = v.VenueName
            }).ToList();

            vm.Venues.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose a venue"
            });
            vm.Vendors = _context.Vendors.Select(v => new SelectListItem
            {
                Value = v.Id.ToString(),
                Text = v.VendorName
            }).ToList();

            vm.Vendors.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose a vendor"
            });
            vm.Customers = _context.Customers.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " "  + c.LastName
            }).ToList();

            vm.Customers.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose a customer"
            });

            return View(vm);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEventViewModel vm)
        {
            if (id != vm.Event.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Event.ApplicationUserId");

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await GetCurrentUserAsync();

                    vm.Event.ApplicationUserId = user.Id;

                    //get any vendors already assigned to the event
                    List<EventVendor> alreadyChosenVendors = await _context.EventVendors.Include(ev => ev.Vendor)
                        .Where(ev => ev.EventId == vm.Event.Id).ToListAsync();

                    //Loop through the vendors we have just chosen
                    vm.SelectedVendors.ForEach(VendorId =>
                    {
                        if (!alreadyChosenVendors.Any(EventVendor => EventVendor.VendorId == VendorId))
                        {
                            EventVendor newVendor = new EventVendor()
                            {
                                EventId = vm.Event.Id,
                                VendorId = VendorId,
                            };
                            //Add new chosen vendors to list
                            _context.EventVendors.Add(newVendor);
                        }
                    });
                    //Loop through previous chosen vendors and check if still chosen, if not delete them from the event's list of selected vendors
                    alreadyChosenVendors.ForEach(eventVendor =>
                    {
                        if (!vm.SelectedVendors.Any(vendorId => vendorId == eventVendor.VendorId))
                        {
                            //remove from list
                            _context.EventVendors.Remove(eventVendor);
                        }
                    });

                    //update information about event 
                    _context.Update(vm.Event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(vm.Event.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", vm.Event.ApplicationUserId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Id", vm.Event.VenueId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Id", vm.SelectedVendors);

            return View(vm);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }

        // get method for calendar view to get events based on dates
        public async Task<IActionResult> Calendar(int ListItem)
        {
            var user = await GetCurrentUserAsync();
            List<Event> items = await _context.Events.Where(e => e.User == user)
                .Include(e => e.Customer)
                .Include(e => e.Venue)
               // .Where(d=> d.EventDate > DateTime.Today)
                .OrderBy(o => o.EventDate).ToListAsync();

            //select drop down to choose time frame this week, next 2 weeks, this month, past events, all events

            List<SelectListItem> selectDate = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "Choose a Date Range", Selected=true
                },
                 new SelectListItem {Text="This Week",Value="1"},
          new SelectListItem {Text="Next Two Weeks",Value="2" },
          new SelectListItem {Text="This Month",Value="3"},
          new SelectListItem {Text="Past Events",Value="4"},
            };
            ViewBag.ListItem = selectDate;


            //if EvenetDate > 1 - 7 days from DateTimeNow
                if (ListItem == 1)
                {
                    items = items.Where(item =>item.EventDate > DateTime.Today && item.EventDate < DateTime.Today.AddDays(7)).ToList();
                                
                 }
                else if (ListItem == 2)
                {
                //if EventDate > 1 -14 days from now
                items = items.Where(item => item.EventDate > DateTime.Today && item.EventDate < DateTime.Today.AddDays(14)).ToList();
                }
                //if EventDate > 1- 30 days
                else if (ListItem == 3)
                {
                items = items.Where(item => item.EventDate > DateTime.Today && item.EventDate < DateTime.Today.AddDays(30)).ToList();
                }
                //if EVentDate < now
                else if (ListItem == 4)
                {
                items = items.Where(item => item.EventDate < DateTime.Today).ToList();
                   
                }
            return View(items);
        }
    }
}
