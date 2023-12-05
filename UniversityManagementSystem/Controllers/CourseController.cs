using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        ICourseManager _courseManager;
        ITeacherManager _teacherManager;
        UniversityMSDbContext _db;
        IEnrollManager _enrollManager;
        IStudentManager _studentManager;
        public CourseController(ICourseManager courseManager, UniversityMSDbContext db, ITeacherManager teacherManager, IEnrollManager enrollManager, IStudentManager studentManager)
        {
            _courseManager = courseManager;
            _db = db;
            _teacherManager = teacherManager;
            _enrollManager = enrollManager;
            _studentManager = studentManager;
        }
        public IActionResult Index()
        {
            try
            {
                var courses = _courseManager.GetAll(c => c.Department, c => c.Semester);
                return View(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Create()
        {
            ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
            ViewData["Semesters"] = new SelectList(_db.Semesters.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isExist = _courseManager.IsCourseExist(course);
                    if (!isExist)
                    {
                        bool isCreated = await _courseManager.AddAsync(course);
                        if (isCreated)
                        {
                            return RedirectToAction("Index");
                        }
                        return View(course);
                    }
                    else
                    {
                        ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
                        ViewData["Semesters"] = new SelectList(_db.Semesters.ToList(), "Id", "Name");
                        ViewBag.message = "Course name and code must be unique.";
                    }

                }
                ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
                ViewData["Semesters"] = new SelectList(_db.Semesters.ToList(), "Id", "Name");
                return View(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var courses =await _courseManager.GetFirstOrDefaultAsync(c => c.Id == id);
            if (courses == null)
            {
                return NotFound();
            }
            ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
            ViewData["Semesters"] = new SelectList(_db.Semesters.ToList(), "Id", "Name");
            return View(courses);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var searchCourse = _courseManager.GetFirstOrDefault(c => c.Id == id);
                    if (searchCourse == null)
                    {
                        return NotFound();
                    }
                    bool isUpdated = await _courseManager.UpdateAsync(course);
                    if (isUpdated)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(course);
                }
                ViewData["Departments"] = new SelectList(_db.Departments.ToList(), "Id", "Code");
                ViewData["Semesters"] = new SelectList(_db.Semesters.ToList(), "Id", "Name");
                return View(course);
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
                var searchCourse =await _courseManager.GetFirstOrDefaultAsync(c => c.Id == id, c => c.Semester, c => c.Department);
                if (searchCourse == null)
                {
                    return NotFound();
                }
                return View(searchCourse);
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
                var searchCourse =await _courseManager.GetFirstOrDefaultAsync(c => c.Id == id, c => c.Semester, c => c.Department);
                if (searchCourse == null)
                {
                    return NotFound();
                }
                return View(searchCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Course course)
        {
            try
            {
                var searchCourse = _courseManager.GetFirstOrDefault(c => c.Id == id, c => c.Semester, c => c.Department);
                if (searchCourse == null)
                {
                    return NotFound();
                }
                bool isDeleted = await _courseManager.DeleteAsync(searchCourse);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
                return View(course);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult AssignCourse()
        {
            ViewBag.Departments = new SelectList(_db.Departments, "Id", "Code");
            ViewBag.Teachers = new SelectList(new List<Teacher>(), "Id", "Name");
            ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignCourse(AssignCourseVM assignCourseVM)
        {
            if(ModelState.IsValid)
            {
                var course = _courseManager.GetFirstOrDefault(c => c.Id == assignCourseVM.CourseId);
                var teachers = _teacherManager.GetAll().Where(c => c.DepartmentId == assignCourseVM.DepartmentId);
                var courses = _courseManager.GetAll().Where(c => c.DepartmentId == assignCourseVM.DepartmentId);
                if (course.TeacherId > 0)
                {
                    ViewBag.Departments = new SelectList(_db.Departments, "Id", "Code");
                    ViewBag.Teachers = new SelectList(teachers, "Id", "Name");
                    ViewBag.Courses = new SelectList(courses, "Id", "Code");
                    ViewBag.Message = "This course is already assigned.";
                    
                    return View(assignCourseVM);
                }
                var teacher = _teacherManager.GetFirstOrDefault(c => c.Id == assignCourseVM.TeacherId);
                if (assignCourseVM.CourseCredit > assignCourseVM.RemainingCredit)
                {
                    ViewBag.Departments = new SelectList(_db.Departments, "Id", "Code");
                    ViewBag.Teachers = new SelectList(teachers, "Id", "Name");
                    ViewBag.Courses = new SelectList(courses, "Id", "Code");
                    ViewBag.Message = "The teacher doesn't have enough credit";
                    return View(assignCourseVM);
                }
                double remainingCredit = assignCourseVM.CreditsToBeTaken - assignCourseVM.CourseCredit;
                course.TeacherId = assignCourseVM.TeacherId;
                teacher.RemainingCredit = remainingCredit;

               
                bool isAssigned = await _courseManager.UpdateAsync(course);
                if (isAssigned)
                {
                    await _teacherManager.UpdateAsync(teacher);
                    return RedirectToAction(nameof(ViewCourseStatus));
                }
                return View(assignCourseVM);
            }
            return View(assignCourseVM);
        }

        [HttpPost]
        public ActionResult GetTeachersByDepartmentId(int departmentId)
        {
            // Get teachers based on the selected Department
            var teachers = _db.Teachers.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(teachers);
        }
        [HttpPost]
        public ActionResult GetTeacherByTeacherId(int teacherId)
        {
            // Get teacher info based on the selected teacherId
            var teacher = _db.Teachers.FirstOrDefault(c => c.Id == teacherId);
            return Json(teacher);
        }
        [HttpPost]
        public ActionResult GetCoursesByDepartmentId(int departmentId)
        {
            // Get courses based on the selected Department
            var courses = _db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }
        [HttpPost]
        public ActionResult GetCourseByCourseId(int courseId)
        {
            // Get course info based on the selected courseId
            var course = _db.Courses.FirstOrDefault(c => c.Id == courseId);
            return Json(course);
        }

        public IActionResult ViewCourseStatus()
        {
            ViewBag.Departments = new SelectList(_db.Departments, "Id", "Code");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ViewCourseStatus(int departmentId)
        {
            ViewBag.Departments = new SelectList(_db.Departments, "Id", "Code");
            var courses = _courseManager.GetAll(c=>c.Teacher).Where(c => c.DepartmentId == departmentId).ToList();
            var courseStatus = from c in courses
                                   join s in _db.Semesters.ToList() on c.SemesterId equals s.Id
                                   select new CourseTeacherMapping
                                   {
                                       Code = c.Code,
                                       Name = c.Name,
                                       SemesterName = s.Name,
                                       AssignTo = c.Teacher != null ? c.Teacher.Name : "Not Assigned Yet"
                                   };
            return Json(courseStatus);
        }

        public IActionResult Enroll()
        {
            ViewBag.Students = new SelectList(_studentManager.GetAll(), "Id", "RegistrationNumber");
            ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollCourseVm enrollCourse)
        {
            if (ModelState.IsValid)
            {
                bool isAlreadyEnrolled = _enrollManager.IsAlreadyEnrolled(enrollCourse.StudentId, enrollCourse.CourseId);
                if (isAlreadyEnrolled)
                {
                    ViewBag.Students = new SelectList(_studentManager.GetAll(), "Id", "RegistrationNumber");
                    ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
                    ViewBag.Message = "This course is already enrolled";
                    return View(enrollCourse);
                }
                Enroll enroll = new Enroll();
                enroll.StudentId = enrollCourse.StudentId;
                enroll.CourseId = enrollCourse.CourseId;
                enroll.Date = enrollCourse.Date;

                bool isSaved = await _enrollManager.AddAsync(enroll);
                if (isSaved)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(enrollCourse);
                
            }
            ViewBag.Students = new SelectList(_studentManager.GetAll(), "Id", "RegistrationNumber");
            ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
            return View(enrollCourse);
        }
        [HttpPost]
        public ActionResult GetStudentByStudentId(int studentId)
        {
            // Get student info based on the selected studentId
            var student = _studentManager.GetFirstOrDefault(c=>c.Id == studentId,c=>c.Department);
            return Json(student);
        }

        public IActionResult UnAssignAllCourses()
        {
            return View();
        }
        [HttpPost]
        [ActionName("UnAssignAllCourses")]
        public async Task<IActionResult> UnAssignCourses()
        {
            var teachers = _teacherManager.GetAll();
            var courses = _courseManager.GetAll();
            foreach (var teacher in teachers)
            {
                teacher.RemainingCredit = teacher.CreditsToBeTaken;
                await _teacherManager.UpdateAsync(teacher);
            }
            foreach (var course in courses)
            {
                course.TeacherId = null;
                await _courseManager.UpdateAsync(course);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
