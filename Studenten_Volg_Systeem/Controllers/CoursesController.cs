using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext db;

        public CoursesController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await db.Courses.ToListAsync());
        }


        // GET: days
        public async Task<IActionResult> Days(int? id)
        {

            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;


            var days = await db.Lessons.Where(d=> d.Course.Id == id).OrderBy(x => x.Date).Select(s => new LessonListItem
            {
                Id = s.Id,
                Date = s.Date,
                Day = s.Date.DayOfWeek,
                Week = myCal.GetWeekOfYear(s.Date, myCWR, myFirstDOW)

            }).ToListAsync();
            ViewBag.coursename = db.Courses.Find(id).Name;

            return View(days);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await db.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Course,StartDate,EndDate,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday")] CourseCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Course course = viewModel.Course;
                db.Add(course);

                double days = (viewModel.EndDate - viewModel.StartDate).TotalDays;
                DateTime currentday = viewModel.StartDate;
                for (double i = 0; i <= days; i++ )
                {
                    if(currentday.DayOfWeek == DayOfWeek.Monday && viewModel.Monday==true)
                    {
                        Lesson lesson = new Lesson { Date = currentday, Course = course };
                        db.Add(lesson);
                    }
                    else if (currentday.DayOfWeek == DayOfWeek.Tuesday && viewModel.Tuesday == true)
                    {
                        Lesson lesson = new Lesson { Date = currentday, Course = course };
                        db.Add(lesson);
                    }
                    else if (currentday.DayOfWeek == DayOfWeek.Wednesday && viewModel.Wednesday == true)
                    {
                        Lesson lesson = new Lesson { Date = currentday, Course = course };
                        db.Add(lesson);
                    }
                    else if (currentday.DayOfWeek == DayOfWeek.Thursday && viewModel.Thursday == true)
                    {
                        Lesson lesson = new Lesson { Date = currentday, Course = course };
                        db.Add(lesson);
                    }
                    else if (currentday.DayOfWeek == DayOfWeek.Friday && viewModel.Friday == true)
                    {
                        Lesson lesson = new Lesson { Date = currentday, Course = course };
                        db.Add(lesson);
                    }
                    else if (currentday.DayOfWeek == DayOfWeek.Saturday && viewModel.Saturday == true)
                    {
                        Lesson lesson = new Lesson { Date = currentday, Course = course };
                        db.Add(lesson);
                    }
                    else if (currentday.DayOfWeek == DayOfWeek.Sunday && viewModel.Sunday == true)
                    {
                        Lesson lesson = new Lesson { Date = currentday, Course = course };
                        db.Add(lesson);
                    }

                    currentday = currentday.AddDays(1);
                }
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(course);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await db.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            db.Lessons.RemoveRange(db.Lessons.Where(s => s.Course.Id == id));
            var course = await db.Courses.FindAsync(id);
            db.Courses.Remove(course);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return db.Courses.Any(e => e.Id == id);
        }
    }
}
