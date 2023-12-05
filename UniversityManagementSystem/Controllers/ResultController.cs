using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ResultController : Controller
    {
        public IResultManager _resultManager;
        public UniversityMSDbContext _db;
        public IStudentManager _studentManager;
        public IEnrollManager _enrollManager;
        public ICourseManager _courseManager;
        public ResultController(IResultManager resultManager, UniversityMSDbContext db, IStudentManager studentManager, IEnrollManager enrollManager, ICourseManager courseManager)
        {
            _resultManager = resultManager;
            _db = db;
            _studentManager = studentManager;
            _enrollManager = enrollManager;
            _courseManager = courseManager;
        }
        public IActionResult Index()
        {
            ViewBag.Students = new SelectList(_studentManager.GetAll(), "Id", "RegistrationNumber");
            return View();
        }

        public IActionResult Save()
        {
            ViewBag.Students = new SelectList(_studentManager.GetAll(), "Id", "RegistrationNumber");
            ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
            ViewBag.Grades = new SelectList(_db.Grades.ToList(), "GradeLetter", "GradeLetter");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(Result result)
        {
            if (ModelState.IsValid)
            {
                bool isAlreadySaved = _resultManager.IsAlreadySaved(result.StudentId, result.CourseId);
                if (isAlreadySaved)
                {
                    ViewBag.Students = new SelectList(_studentManager.GetAll(), "Id", "RegistrationNumber");
                    ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
                    ViewBag.Grades = new SelectList(_db.Grades.ToList(), "GradeLetter", "GradeLetter");
                    ViewBag.Message = "This students result for this course is already saved.";
                    return View(result);
                }
                var enroll = _enrollManager.GetFirstOrDefault(c=>c.StudentId== result.StudentId && c.CourseId==result.CourseId);
                bool isSaved = await _resultManager.AddAsync(result);
                if (isSaved)
                {
                    enroll.Grade = result.Grade;
                    await _enrollManager.UpdateAsync(enroll);
                    return RedirectToAction("Index");
                }
                return View(result);
            }
            ViewBag.Students = new SelectList(_studentManager.GetAll(), "Id", "RegistrationNumber");
            ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
            ViewBag.Grades = new SelectList(_db.Grades.ToList(), "GradeLetter", "GradeLetter");
            return View(result);
        }
        [HttpPost]
        public ActionResult GetStudentByStudentId(int studentId)
        {
            // Get student info based on the selected studentId
            var student = _studentManager.GetFirstOrDefault(c => c.Id == studentId, c => c.Department);
            return Json(student);
        }
        [HttpPost]
        public ActionResult GetEnrolledCoursesByStudentId(int studentId)
        {
            // Get enrolled courses info based on the selected studentId
            var courses = from s in _studentManager.GetAll()
                          join e in _enrollManager.GetAll() on s.Id equals e.StudentId
                          join c in _courseManager.GetAll() on e.CourseId equals c.Id
                          where s.Id == studentId
                          select c;
            return Json(courses);
        }

        [HttpPost]
        public ActionResult GetResultsByStudentId(int studentId)
        {
            var studentInfo = from s in _studentManager.GetAll()
                              join e in _enrollManager.GetAll() on s.Id equals e.StudentId
                              join c in _courseManager.GetAll() on e.CourseId equals c.Id
                              where s.Id == studentId
                              select new
                              {
                                  CourseCode = c.Code, 
                                  CourseName = c.Name,
                                  Grade = e.Grade ?? "Not Graded Yet"
                              };

            return Json(studentInfo);
        }
    }
}
