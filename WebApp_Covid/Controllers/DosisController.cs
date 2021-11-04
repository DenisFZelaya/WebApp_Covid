using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_Covid.Context;
using WebApp_Covid.Models;

namespace WebApp_Covid.Controllers
{
    public class DosisController : Controller
    {
        private readonly appDbContext _context;

        public DosisController(appDbContext context)
        {
            _context = context;
        }

        // GET: Dosis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dosis.ToListAsync());
        }

        // GET: Dosis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosis = await _context.Dosis
                .FirstOrDefaultAsync(m => m.DosisVacunaId == id);
            if (dosis == null)
            {
                return NotFound();
            }

            return View(dosis);
        }

        // GET: Dosis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dosis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosisVacunaId,Descripcion,Estado")] Dosis dosis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dosis);
        }

        // GET: Dosis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosis = await _context.Dosis.FindAsync(id);
            if (dosis == null)
            {
                return NotFound();
            }
            return View(dosis);
        }

        // POST: Dosis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DosisVacunaId,Descripcion,Estado")] Dosis dosis)
        {
            if (id != dosis.DosisVacunaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosisExists(dosis.DosisVacunaId))
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
            return View(dosis);
        }

        // GET: Dosis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosis = await _context.Dosis
                .FirstOrDefaultAsync(m => m.DosisVacunaId == id);
            if (dosis == null)
            {
                return NotFound();
            }

            return View(dosis);
        }

        // POST: Dosis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dosis = await _context.Dosis.FindAsync(id);
            _context.Dosis.Remove(dosis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosisExists(int id)
        {
            return _context.Dosis.Any(e => e.DosisVacunaId == id);
        }
    }
}
