using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RuilwinkelVerhuur.Models;
using RuilwinkelVerhuur.Models.Classes;

namespace RuilwinkelVerhuur.Controllers
{
    public class FactuursController : Controller
    {
        private readonly DatabaseContext _context;

        public FactuursController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Factuurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Factuur.ToListAsync());
        }

        // GET: Factuurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuur = await _context.Factuur
                .FirstOrDefaultAsync(m => m.ID == id);
            if (factuur == null)
            {
                return NotFound();
            }

            return View(factuur);
        }

        // GET: Factuurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Factuurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,Date")] Factuur factuur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factuur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factuur);
        }

        // GET: Factuurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuur = await _context.Factuur.FindAsync(id);
            if (factuur == null)
            {
                return NotFound();
            }
            return View(factuur);
        }

        // POST: Factuurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,Date")] Factuur factuur)
        {
            if (id != factuur.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factuur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactuurExists(factuur.ID))
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
            return View(factuur);
        }

        // GET: Factuurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuur = await _context.Factuur
                .FirstOrDefaultAsync(m => m.ID == id);
            if (factuur == null)
            {
                return NotFound();
            }

            return View(factuur);
        }

        // POST: Factuurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factuur = await _context.Factuur.FindAsync(id);
            _context.Factuur.Remove(factuur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactuurExists(int id)
        {
            return _context.Factuur.Any(e => e.ID == id);
        }
    }
}
