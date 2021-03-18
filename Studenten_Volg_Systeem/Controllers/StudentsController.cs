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
    public class StudentsController : Controller
    {

       // private ApplicationDbContext db = new ApplicationDbContext();

        private readonly ApplicationDbContext db;

        public StudentsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await db.Students.Select(s => new StudentListItemViewModel {
                Id = s.Id,
                Fullname = s.Firstname + " " + s.Lastname,
                Course = s.Course.Name

            }).ToListAsync();

            //var StudentenViewModel = new StudentListItemViewModel
            //{
            //    Student = new Student(),
            //    Courses = db.Courses.ToList()
            //};

            return View(students);
            //return View(await db.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {

            var ViewModel = new StudentCreateViewModel
            {
                Student = new Student(),
                Courses = db.Courses.ToList()
            };
            return View(ViewModel);
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Student,CourseID")] StudentCreateViewModel studentCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var student = studentCreateViewModel.Student;
                student.Course = db.Courses.Find(studentCreateViewModel.CourseID);
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentCreateViewModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewmodel =  new StudentCreateViewModel {
                Student = db.Students.Include(r => r.Course).FirstOrDefault(r => r.Id == id),
                Courses = db.Courses.ToList()
            };
            //await db.Students.FindAsync(id);
            viewmodel.CourseID = viewmodel.Student.Course.Id;
            if (viewmodel == null)
            {
                return NotFound();
            }
            return View(viewmodel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Student,CourseID")] StudentCreateViewModel studentCreateViewModel)
        {
            if (id != studentCreateViewModel.Student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var student = studentCreateViewModel.Student;
                    student.Course = db.Courses.Find(studentCreateViewModel.CourseID);
                    db.Update(student);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(studentCreateViewModel.Student.Id))
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
            return View(studentCreateViewModel);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return db.Students.Any(e => e.Id == id);
        }
    }
}
