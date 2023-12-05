using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class AllocateController : Controller
    {
        private UniversityMSDbContext _db;
        private IDepartmentManager _departmentManager;
        private IAllocateManager _allocateManager;

        public AllocateController(UniversityMSDbContext db, IAllocateManager allocateManager, IDepartmentManager departmentManager)
        {
            _db = db;
            _allocateManager = allocateManager;
            _departmentManager = departmentManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllocateRoom()
        {
            ViewBag.Departments = new SelectList(_departmentManager.GetAll(), "Id", "Code");
            ViewBag.Rooms = new SelectList(_db.Rooms, "Id", "RoomNo");
            ViewBag.Days = new SelectList(_db.Days, "Id", "DayName");
            ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AllocateRoom(Allocate allocate)
        {

            if (ModelState.IsValid)
            {
                bool isAllocated = _allocateManager.IsAllocated(allocate);
                if (isAllocated)
                {
                    ViewBag.Departments = new SelectList(_departmentManager.GetAll(), "Id", "Code");
                    ViewBag.Rooms = new SelectList(_db.Rooms, "Id", "RoomNo");
                    ViewBag.Days = new SelectList(_db.Days, "Id", "DayName");
                    ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
                    ViewBag.message = "Room is already allocated please select another room";
                    return View(allocate);
                }
                bool isSaved = await _allocateManager.AddAsync(allocate);
                if (isSaved)
                {
                    return RedirectToAction(nameof(ViewRoomSchedule));
                }
                return View(allocate);
            }
            ViewBag.Departments = new SelectList(_departmentManager.GetAll(), "Id", "Code");
            ViewBag.Rooms = new SelectList(_db.Rooms, "Id", "RoomNo");
            ViewBag.Days = new SelectList(_db.Days, "Id", "DayName");
            ViewBag.Courses = new SelectList(new List<Course>(), "Id", "Code");
            return View(allocate);
        }
        [HttpPost]
        public ActionResult GetCoursesByDepartmentId(int departmentId)
        {
            // Get courses based on the selected Department
            var courses = _db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }
        public async Task<IActionResult> ViewRoomSchedule()
        {
            ViewBag.Departments = new SelectList(_db.Departments, "Id", "Code");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ViewRoomSchedule(int departmentId)
        {
            ViewBag.Departments = new SelectList(_db.Departments, "Id", "Code");

            var allCourse = _db.Courses.Where(c => c.DepartmentId == departmentId).ToList();

            var allocates = _allocateManager.GetAll(a => a.Course, a => a.Day, a => a.Room)
                            .Where(c => c.DepartmentId == departmentId)
                            .GroupBy(c => new { c.CourseId, c.Course.Code, c.Course.Name })
                            .Select(group => new
                            {
                                CourseId = group.Key.CourseId,
                                Code = group.Key.Code,
                                Name = group.Key.Name,
                                ScheduleInfo = group.Select(item => new
                                {
                                    RoomNo = item.Room.RoomNo,
                                    DayName = item.Day.DayName.Substring(0, 3),
                                    FromTime = item.FromTime,
                                    ToTime = item.ToTime
                                }).ToList()
                            }).ToList();

            // Left outer join to include unallocated courses
            var result = from course in allCourse
                         join allocate in allocates
                             on course.Id equals allocate.CourseId into courseAllocates
                         from ca in courseAllocates.DefaultIfEmpty()
                         select new
                         {
                             CourseId = course.Id,
                             Code = course.Code,
                             Name = course.Name,
                             ScheduleInfo = ca != null ?
                                 ca.ScheduleInfo :
                                 (IEnumerable<object>)new List<object> { new { RoomNo = "Not allocated yet" } }
                         };



            return Json(result.ToList());
        }

        public IActionResult UnAllocateAllRooms()
        {
            return View();
        }
        [HttpPost]
        [ActionName("UnAllocateAllRooms")]
        public async Task<IActionResult> UnAllocateRooms()
        {
            var allocates = _allocateManager.GetAll();
            bool isUnAllocated = await _allocateManager.DeleteAsync(allocates);
            if (isUnAllocated)
            {
                return RedirectToAction(nameof(ViewRoomSchedule));
            }
            return View();
        }
    }
}
