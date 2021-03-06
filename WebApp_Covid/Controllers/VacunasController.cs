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
    public class VacunasController : Controller
    {
        private readonly appDbContext _context;

        public VacunasController(appDbContext context)
        {
            _context = context;
        }

        // GET: Vacunas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vacunas.ToListAsync());
        }

        // GET: Vacunas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacunas = await _context.Vacunas
                .FirstOrDefaultAsync(m => m.VacunaId == id);
            if (vacunas == null)
            {
                return NotFound();
            }

            return View(vacunas);
        }

        // GET: Vacunas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vacunas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacunaId,Descripcion,Estado")] Vacunas vacunas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacunas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacunas);
        }

        // GET: Vacunas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacunas = await _context.Vacunas.FindAsync(id);
            if (vacunas == null)
            {
                return NotFound();
            }
            return View(vacunas);
        }

        // POST: Vacunas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacunaId,Descripcion,Estado")] Vacunas vacunas)
        {
            if (id != vacunas.VacunaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacunas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacunasExists(vacunas.VacunaId))
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
            return View(vacunas);
        }

        // GET: Vacunas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacunas = await _context.Vacunas
                .FirstOrDefaultAsync(m => m.VacunaId == id);
            if (vacunas == null)
            {
                return NotFound();
            }

            return View(vacunas);
        }

        // POST: Vacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacunas = await _context.Vacunas.FindAsync(id);
            _context.Vacunas.Remove(vacunas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacunasExists(int id)
        {
            return _context.Vacunas.Any(e => e.VacunaId == id);
        }
    }
}
