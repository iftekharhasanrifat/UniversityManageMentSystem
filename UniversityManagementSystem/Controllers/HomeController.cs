using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IDepartmentManager _departmentManager;
        public ITeacherManager _teacherManager;
        public HomeController(ILogger<HomeController> logger, IDepartmentManager departmentManager, ITeacherManager teacherManager)
        {
            _logger = logger;
            _departmentManager = departmentManager;
            _teacherManager = teacherManager;
        }

        public IActionResult Index()
        {
            var teachers = _teacherManager.GetAll();
            var departments = _departmentManager.GetAll();
            ViewBag.Teachers = teachers;
            ViewBag.Departments = departments;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}