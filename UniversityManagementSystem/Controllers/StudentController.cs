using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.DependencyResolver;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        IDepartmentManager _departmentManager;
        IStudentManager _studentManager;
        public StudentController(IStudentManager studentManager, IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
            _studentManager = studentManager;
        }
        public IActionResult Index()
        {
            return View(_studentManager.GetAll());
        }

        public IActionResult Create()
        {
            ViewData["Departments"] = new SelectList(_departmentManager.GetAll(), "Id", "Code");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isExist = _studentManager.IsEmailExist(student);
                    if (!isExist)
                    {
                        student.RegistrationNumber = _studentManager.GenerateRegistrationNumber(student);
                        bool isCreated = await _studentManager.AddAsync(student);
                        if (isCreated)
                        {
                            return RedirectToAction("Index");
                        }
                        ViewData["Departments"] = new SelectList(_departmentManager.GetAll(), "Id", "Code");
                        return View(student);
                    }
                    else
                    {
                        ViewData["Departments"] = new SelectList(_departmentManager.GetAll(), "Id", "Code");
                        ViewBag.message = "This Email is already in use.";
                    }

                }
                ViewData["Departments"] = new SelectList(_departmentManager.GetAll(), "Id", "Code");
                return View(student);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
