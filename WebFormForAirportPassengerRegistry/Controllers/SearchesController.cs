using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebFormForAirportPassengerRegistry;

namespace WebFormForAirportPassengerRegistry.Controllers
{
    public class SearchesController : Controller
    {
        private readonly AirportPassengerRegistryContext _context;

        public SearchesController(AirportPassengerRegistryContext context)
        {
            _context = context;
        }

        // GET: Searches
        public async Task<IActionResult> Index()
        {
            var airportPassengerRegistryContext = _context.Searches.Include(s => s.Passenger);
            return View(await airportPassengerRegistryContext.ToListAsync());
        }

        // GET: Searches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Searches == null)
            {
                return NotFound();
            }

            var search = await _context.Searches
                .Include(s => s.Passenger)
                .FirstOrDefaultAsync(m => m.SearchId == id);
            if (search == null)
            {
                return NotFound();
            }

            return View(search);
        }

        // GET: Searches/Create
        public IActionResult Create()
        {
            ViewData["PassengerId"] = new SelectList(_context.Passengers, "PassengerId", "PassengerId");
            return View();
        }

        // POST: Searches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SearchId,DateSince,ExpiryDate,Reason,PassengerId,FullName,Birthdate,Sex")] Search search)
        {
            if (ModelState.IsValid)
            {
                _context.Add(search);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PassengerId"] = new SelectList(_context.Passengers, "PassengerId", "PassengerId", search.PassengerId);
            return View(search);
        }

        // GET: Searches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Searches == null)
            {
                return NotFound();
            }

            var search = await _context.Searches.FindAsync(id);
            if (search == null)
            {
                return NotFound();
            }
            ViewData["PassengerId"] = new SelectList(_context.Passengers, "PassengerId", "PassengerId", search.PassengerId);
            return View(search);
        }

        // POST: Searches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SearchId,DateSince,ExpiryDate,Reason,PassengerId,FullName,Birthdate,Sex")] Search search)
        {
            if (id != search.SearchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(search);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SearchExists(search.SearchId))
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
            ViewData["PassengerId"] = new SelectList(_context.Passengers, "PassengerId", "PassengerId", search.PassengerId);
            return View(search);
        }

        // GET: Searches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Searches == null)
            {
                return NotFound();
            }

            var search = await _context.Searches
                .Include(s => s.Passenger)
                .FirstOrDefaultAsync(m => m.SearchId == id);
            if (search == null)
            {
                return NotFound();
            }

            return View(search);
        }

        // POST: Searches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Searches == null)
            {
                return Problem("Entity set 'AirportPassengerRegistryContext.Searches'  is null.");
            }
            var search = await _context.Searches.FindAsync(id);
            if (search != null)
            {
                _context.Searches.Remove(search);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SearchExists(int id)
        {
          return (_context.Searches?.Any(e => e.SearchId == id)).GetValueOrDefault();
        }
    }
}
