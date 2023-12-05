using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherManager _teacherManager;
        private UniversityMSDbContext _db;
        public TeacherController(ITeacherManager teacherManager, UniversityMSDbContext db)
        {
            _teacherManager = teacherManager;
            _db = db;
        }
        public IActionResult Index()
        {
            try
            {
                return View(_teacherManager.GetAll(c => c.Department, c => c.Designation));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> Create()
        {
            ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
            ViewData["Designations"] = new SelectList(_db.Designations.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isExist = _teacherManager.IsEmailExist(teacher);
                    if (!isExist)
                    {
                        teacher.RemainingCredit = teacher.CreditsToBeTaken;
                        bool isCreated = await _teacherManager.AddAsync(teacher);
                        if (isCreated)
                        {
                            return RedirectToAction("Index");
                        }
                        return View(teacher);
                    }
                    else
                    {
                        ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
                        ViewData["Designations"] = new SelectList(_db.Designations.ToList(), "Id", "Name");
                        ViewBag.message = "This Email is already in use.";
                    }

                }
                ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
                ViewData["Designations"] = new SelectList(_db.Designations.ToList(), "Id", "Name");
                return View(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var searchTeacher = _teacherManager.GetFirstOrDefault(c => c.Id == id);
            if (searchTeacher == null)
            {
                return NotFound();
            }
            ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
            ViewData["Designations"] = new SelectList(_db.Designations.ToList(), "Id", "Name");
            return View(searchTeacher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var searchTeacher = _teacherManager.GetFirstOrDefault(c => c.Id == id);
                    if (searchTeacher == null)
                    {
                        return NotFound();
                    }
                    double extraCredit = 0;
                    if (teacher.CreditsToBeTaken >= searchTeacher.CreditsToBeTaken)
                    {
                        extraCredit = teacher.CreditsToBeTaken - searchTeacher.CreditsToBeTaken;
                    }
                    teacher.RemainingCredit = searchTeacher.RemainingCredit + extraCredit;
                    bool isUpdated = await _teacherManager.UpdateAsync(teacher);
                    if (isUpdated)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(teacher);

                }
                ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
                ViewData["Designations"] = new SelectList(_db.Designations.ToList(), "Id", "Name");
                return View(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var searchTeacher = _teacherManager.GetFirstOrDefault(c => c.Id == id, c => c.Designation, c => c.Department);
                if (searchTeacher == null)
                {
                    return NotFound();
                }
                return View(searchTeacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var searchTeacher = _teacherManager.GetFirstOrDefault(c => c.Id == id, c => c.Designation, c => c.Department);
                if (searchTeacher == null)
                {
                    return NotFound();
                }
                return View(searchTeacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Teacher teacher)
        {
            try
            {
                var searchTeacher = _teacherManager.GetFirstOrDefault(c => c.Id == id, c => c.Courses);

                // Remove references from courses
                foreach (var course in searchTeacher.Courses.ToList())
                {
                    course.TeacherId = null;
                }
                
                if (searchTeacher == null)
                {
                    return NotFound();
                }
                bool isDeleted = await _teacherManager.DeleteAsync(searchTeacher);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
                return View(teacher);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
