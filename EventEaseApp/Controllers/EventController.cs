using EventEaseApp.Data;
using EventEaseApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventEaseApp.Controllers
{
    public class EventController : Controller
    {
        private readonly EventEaseAppContext _context;

        public EventController(EventEaseAppContext context)
        {
            _context = context;
        }

        // GET: EventController
        public async Task<ActionResult> Index()
        {
            var events = await _context.Event_.ToListAsync();
            return View(events);
        }


        // GET: EventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var eventItem = await _context.Event_.Include(e => e.EventID).FirstOrDefaultAsync(e => e.EventID == id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View(eventItem);
        }


        // GET: EventController/Create
        public IActionResult Create()
        {
            //ViewBag.VenueID = new SelectList(_context.Venue, "VenueID", "VenueName");
            return View();
        }


        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("EventName, EventDate, Description")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venue);

        }

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var events = await _context.Event_.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("EventName, EventDate, Description")] Event eventItem)
        {
            if (id != eventItem.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Event_.Any(e => e.EventID == eventItem.EventID))
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
            return View(eventItem);
        }

        // GET: EventController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var eventItem = await _context.Event_.FirstOrDefaultAsync(e => e.EventID == id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View(eventItem);
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var eventItem = await _context.Event_.FindAsync(id);
            if (eventItem != null)
            {
                _context.Event_.Remove(eventItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
