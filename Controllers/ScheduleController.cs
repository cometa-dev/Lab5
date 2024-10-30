using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ScheduleDbContext _context;

        public ScheduleController(ScheduleDbContext context)  // Изменение здесь
        {
            _context = context;
        }

   
        public async Task<IActionResult> Index()
        {
            var schedules = await _context.Schedules
                .Include(s => s.ClassPeriod)
                .Include(s => s.Classroom)
                .Include(s => s.Group)
                .Include(s => s.Instructor)
                .ToListAsync();
            return View(schedules);
        }

        public IActionResult Create()
        {
            ViewData["ClassPeriodId"] = new SelectList(_context.ClassPeriods, "Id", "Time");
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Number");
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "Name");
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupId,InstructorId,ClassroomId,ClassPeriodId")] Schedule schedule)
        {
         
            Console.WriteLine($"GroupId: {schedule.GroupId}");
            Console.WriteLine($"InstructorId: {schedule.InstructorId}");
            Console.WriteLine($"ClassroomId: {schedule.ClassroomId}");
            Console.WriteLine($"ClassPeriodId: {schedule.ClassPeriodId}");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(schedule);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving to database: {ex.Message}");
                    ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }
            }

            ViewData["ClassPeriodId"] = new SelectList(_context.ClassPeriods, "Id", "Time", schedule.ClassPeriodId);
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Number", schedule.ClassroomId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", schedule.GroupId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "Name", schedule.InstructorId);
            return View(schedule);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            ViewData["ClassPeriodId"] = new SelectList(_context.ClassPeriods, "Id", "Time", schedule.ClassPeriodId);
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Number", schedule.ClassroomId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", schedule.GroupId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "Name", schedule.InstructorId);
            return View(schedule);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupId,InstructorId,ClassroomId,ClassPeriodId")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
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
            ViewData["ClassPeriodId"] = new SelectList(_context.ClassPeriods, "Id", "Time", schedule.ClassPeriodId);
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Number", schedule.ClassroomId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", schedule.GroupId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "Name", schedule.InstructorId);
            return View(schedule);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.ClassPeriod)
                .Include(s => s.Classroom)
                .Include(s => s.Group)
                .Include(s => s.Instructor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.ClassPeriod)
                .Include(s => s.Classroom)
                .Include(s => s.Group)
                .Include(s => s.Instructor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}