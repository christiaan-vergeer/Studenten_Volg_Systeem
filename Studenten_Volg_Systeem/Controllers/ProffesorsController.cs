using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Studenten_Volg_Systeem.Data;
using Studenten_Volg_Systeem.Models;
using Studenten_Volg_Systeem.ViewModels;

namespace Studenten_Volg_Systeem
{
    public class ProffesorsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProffesorsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Proffesors
        public async Task<IActionResult> Index()
        {

            var students = await db.Proffesors.Select(s => new StudentListItemViewModel
            {
                Id = s.Id,
                Fullname = s.Name,
                Course = s.Courses.Name

            }).ToListAsync();

            return View(students);
        }

        // GET: Proffesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proffesor = await db.Proffesors.Include(m => m.Courses)
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
            var ViewModel = new ProfessorCreateViewModel
            {
                Proffesor = new Proffesor(),
                Courses = db.Courses.ToList()
            };
            return View(ViewModel);
        }

        // POST: Proffesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Proffesor,CourseID")] ProfessorCreateViewModel professorCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var proffesor = professorCreateViewModel.Proffesor;
                proffesor.Courses = db.Courses.Find(professorCreateViewModel.CourseID);
                db.Proffesors.Add(proffesor);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professorCreateViewModel);
        }

        // GET: Proffesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewmodel = new ProfessorCreateViewModel
            {
                Proffesor = db.Proffesors.Include(r => r.Courses).FirstOrDefault(r => r.Id == id),
                Courses = db.Courses.ToList()
            };
            //await db.Students.FindAsync(id);
            viewmodel.CourseID = viewmodel.Proffesor.Courses.Id;

            //var proffesor = await db.Proffesors.FindAsync(id);
            if (viewmodel == null)
            {
                return NotFound();
            }
            return View(viewmodel);
        }

        // POST: Proffesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Proffesor,CourseID")] ProfessorCreateViewModel professorCreateViewModel)
        {
            if (id != professorCreateViewModel.Proffesor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var proffesor = professorCreateViewModel.Proffesor;
                    proffesor.Courses = db.Courses.Find(professorCreateViewModel.CourseID);
                    db.Update(proffesor);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProffesorExists(professorCreateViewModel.Proffesor.Id))
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
            return View(professorCreateViewModel);
        }

        // GET: Proffesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proffesor = await db.Proffesors.Include(m => m.Courses)
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
            var proffesor = await db.Proffesors.FindAsync(id);
            db.Proffesors.Remove(proffesor);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProffesorExists(int id)
        {
            return db.Proffesors.Any(e => e.Id == id);
        }
    }
}
