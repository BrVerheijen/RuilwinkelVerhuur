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
    public class ProductNaarFactuursController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductNaarFactuursController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProductNaarFactuurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductNaarFactuur.ToListAsync());
        }

        // GET: ProductNaarFactuurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productNaarFactuur = await _context.ProductNaarFactuur
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productNaarFactuur == null)
            {
                return NotFound();
            }

            return View(productNaarFactuur);
        }

        // GET: ProductNaarFactuurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductNaarFactuurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductID,FactuurID,StartDate,HuurLengte")] ProductNaarFactuur productNaarFactuur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productNaarFactuur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productNaarFactuur);
        }

        // GET: ProductNaarFactuurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productNaarFactuur = await _context.ProductNaarFactuur.FindAsync(id);
            if (productNaarFactuur == null)
            {
                return NotFound();
            }
            return View(productNaarFactuur);
        }

        // POST: ProductNaarFactuurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductID,FactuurID,StartDate,HuurLengte")] ProductNaarFactuur productNaarFactuur)
        {
            if (id != productNaarFactuur.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productNaarFactuur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductNaarFactuurExists(productNaarFactuur.ID))
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
            return View(productNaarFactuur);
        }

        // GET: ProductNaarFactuurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productNaarFactuur = await _context.ProductNaarFactuur
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productNaarFactuur == null)
            {
                return NotFound();
            }

            return View(productNaarFactuur);
        }

        // POST: ProductNaarFactuurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productNaarFactuur = await _context.ProductNaarFactuur.FindAsync(id);
            _context.ProductNaarFactuur.Remove(productNaarFactuur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductNaarFactuurExists(int id)
        {
            return _context.ProductNaarFactuur.Any(e => e.ID == id);
        }
    }
}
