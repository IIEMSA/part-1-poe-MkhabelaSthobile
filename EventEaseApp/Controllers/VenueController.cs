using EventEaseApp.Data;
using EventEaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEaseApp.Controllers
{
    public class VenueController : Controller
    {
        private readonly EventEaseAppContext _context;

        public VenueController(EventEaseAppContext context)
        {
            _context = context;
        }

        // GET: VenueController
        public async Task<ActionResult> Index()
        {
            var venue = await _context.Venue.ToListAsync();
            return View(venue);
        }

        // GET: VenueController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var venue = await _context.Venue.FirstOrDefaultAsync(v => v.VenueID == id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        // POST: VenueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue);
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        // GET: VenueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: VenueController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var venue = await _context.Venue.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        // POST: VenueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Venue venue)
        {
            if (id != venue.VenueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Venue.Any(v => v.VenueID == venue.VenueID))
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
            return View(venue);
        }

        // GET: VenueController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var venue = await _context.Venue.FirstOrDefaultAsync(v => v.VenueID == id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        // POST: VenueController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var venue = await _context.Venue.FindAsync(id);
            if (venue != null)
            {
                _context.Venue.Remove(venue);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
