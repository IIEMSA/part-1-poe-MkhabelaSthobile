using EventEaseApp.Data;
using EventEaseApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEaseApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly EventEaseAppContext _context;

        public BookingController(EventEaseAppContext context)
        {
            _context = context;
        }

        // GET: BookingController
        public async Task<ActionResult> Index()
        {
            var bookings = await _context.Booking.ToListAsync();
            return View(bookings);
        }

        // GET: BookingController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(b => b.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("BookingDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);

        }

        // GET: BookingController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("BookingDate")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Booking.Any(b => b.BookingID == booking.BookingID))
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
            return View(booking);
        }

        // GET: BookingController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(b => b.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking != null)
            {
                _context.Booking.Remove(booking);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
