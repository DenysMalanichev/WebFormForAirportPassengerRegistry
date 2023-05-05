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
    public class TerminalsController : Controller
    {
        private readonly AirportPassengerRegistryContext _context;

        public TerminalsController(AirportPassengerRegistryContext context)
        {
            _context = context;
        }

        // GET: Terminals
        public async Task<IActionResult> Index()
        {
              return _context.Terminals != null ? 
                          View(await _context.Terminals.ToListAsync()) :
                          Problem("Entity set 'AirportPassengerRegistryContext.Terminals'  is null.");
        }

        // GET: Terminals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Terminals == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminals
                .FirstOrDefaultAsync(m => m.TerminalId == id);
            if (terminal == null)
            {
                return NotFound();
            }

            return View(terminal);
        }

        // GET: Terminals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Terminals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TerminalId,Name")] Terminal terminal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terminal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terminal);
        }

        // GET: Terminals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Terminals == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminals.FindAsync(id);
            if (terminal == null)
            {
                return NotFound();
            }
            return View(terminal);
        }

        // POST: Terminals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TerminalId,Name")] Terminal terminal)
        {
            if (id != terminal.TerminalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terminal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerminalExists(terminal.TerminalId))
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
            return View(terminal);
        }

        // GET: Terminals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Terminals == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminals
                .FirstOrDefaultAsync(m => m.TerminalId == id);
            if (terminal == null)
            {
                return NotFound();
            }

            return View(terminal);
        }

        // POST: Terminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Terminals == null)
            {
                return Problem("Entity set 'AirportPassengerRegistryContext.Terminals'  is null.");
            }
            var terminal = await _context.Terminals.FindAsync(id);
            if (terminal != null)
            {
                _context.Terminals.Remove(terminal);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return View("ErrorDeleting");
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool TerminalExists(int id)
        {
          return (_context.Terminals?.Any(e => e.TerminalId == id)).GetValueOrDefault();
        }
    }
}
