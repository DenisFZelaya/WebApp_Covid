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
    public class VacunacionCovid19Controller : Controller
    {
        private readonly appDbContext _context;

        public VacunacionCovid19Controller(appDbContext context)
        {
            _context = context;
        }

        // GET: VacunacionCovid19
        public async Task<IActionResult> Index()
        {
            return View(await _context.VacunacionCovid19.ToListAsync());
        }

        // GET: VacunacionCovid19/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacunacionCovid19 = await _context.VacunacionCovid19
                .FirstOrDefaultAsync(m => m.VacunacionId == id);
            if (vacunacionCovid19 == null)
            {
                return NotFound();
            }

            return View(vacunacionCovid19);
        }

        // GET: VacunacionCovid19/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VacunacionCovid19/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacunacionId,FkPacienteId,FkVacunaId,FkDosisId,FechaCreacion,FechaUltimaModificacion")] VacunacionCovid19 vacunacionCovid19)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacunacionCovid19);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacunacionCovid19);
        }

        // GET: VacunacionCovid19/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacunacionCovid19 = await _context.VacunacionCovid19.FindAsync(id);
            if (vacunacionCovid19 == null)
            {
                return NotFound();
            }
            return View(vacunacionCovid19);
        }

        // POST: VacunacionCovid19/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacunacionId,FkPacienteId,FkVacunaId,FkDosisId,FechaCreacion,FechaUltimaModificacion")] VacunacionCovid19 vacunacionCovid19)
        {
            if (id != vacunacionCovid19.VacunacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacunacionCovid19);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacunacionCovid19Exists(vacunacionCovid19.VacunacionId))
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
            return View(vacunacionCovid19);
        }

        // GET: VacunacionCovid19/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacunacionCovid19 = await _context.VacunacionCovid19
                .FirstOrDefaultAsync(m => m.VacunacionId == id);
            if (vacunacionCovid19 == null)
            {
                return NotFound();
            }

            return View(vacunacionCovid19);
        }

        // POST: VacunacionCovid19/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacunacionCovid19 = await _context.VacunacionCovid19.FindAsync(id);
            _context.VacunacionCovid19.Remove(vacunacionCovid19);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacunacionCovid19Exists(int id)
        {
            return _context.VacunacionCovid19.Any(e => e.VacunacionId == id);
        }
    }
}
