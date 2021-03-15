using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Studenten_Volg_Systeem.Data;
using Studenten_Volg_Systeem.Models;

namespace Studenten_Volg_Systeem
{
    public class ProffesorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProffesorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proffesors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proffesors.ToListAsync());
        }

        // GET: Proffesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proffesor = await _context.Proffesors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proffesor == null)
            {
                return NotFound();
            }

            return View(proffesor);
        }

        // GET: Proffesors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proffesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Proffesor proffesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proffesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proffesor);
        }

        // GET: Proffesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proffesor = await _context.Proffesors.FindAsync(id);
            if (proffesor == null)
            {
                return NotFound();
            }
            return View(proffesor);
        }

        // POST: Proffesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Proffesor proffesor)
        {
            if (id != proffesor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proffesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProffesorExists(proffesor.Id))
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
            return View(proffesor);
        }

        // GET: Proffesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proffesor = await _context.Proffesors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proffesor == null)
            {
                return NotFound();
            }

            return View(proffesor);
        }

        // POST: Proffesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proffesor = await _context.Proffesors.FindAsync(id);
            _context.Proffesors.Remove(proffesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProffesorExists(int id)
        {
            return _context.Proffesors.Any(e => e.Id == id);
        }
    }
}
