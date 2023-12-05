using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentManager _departmentManager;
        private UniversityMSDbContext _db;
        public DepartmentController(IDepartmentManager departmentManager, UniversityMSDbContext db)
        {
            _db = db;
            _departmentManager = departmentManager;
        }
        //private UniversityMSDbContext _db;
        //public DepartmentController(UniversityMSDbContext db)
        //{
        //    _db = db;
        //}
        public IActionResult Index()
        {
            try
            {
                return View(_departmentManager.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Create()
        {
            //ViewData["Semesters"]= new SelectList( _db.Semesters.ToList(),"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isExist = _departmentManager.IsDepartmentExist(department);
                    if (!isExist)
                    {
                        bool isCreated = await _departmentManager.AddAsync(department);
                        if (isCreated)
                        {
                            return RedirectToAction("Index");
                        }
                        return View(department);
                    }
                    else
                    {
                        ViewBag.message = "Department name and code must be unique.";
                    }
                   
                }
                return View(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var department = _departmentManager.GetFirstOrDefault(c => c.Id == id);
                if (department == null)
                {
                    return NotFound();
                }
                return View(department);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            try
            {
               if (ModelState.IsValid)
                {
                    var searchDepartment = _departmentManager.GetFirstOrDefault(c => c.Id == id);
                    if (searchDepartment == null)
                    {
                        return NotFound();
                    }
                    bool isUpdted = await _departmentManager.UpdateAsync(department);
                    if (isUpdted)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(department);
                   
                }
               return View(department);
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
                var searchDepartment = _departmentManager.GetFirstOrDefault(c => c.Id == id);
                if (searchDepartment == null)
                {
                    return NotFound();
                }
                return View(searchDepartment);
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
                var searchDepartment = _departmentManager.GetFirstOrDefault(c => c.Id == id);
                if (searchDepartment == null)
                {
                    return NotFound();
                }

                return View(searchDepartment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Department department)
        {
            try
            {
                var searchDepartment = _departmentManager.GetFirstOrDefault(c => c.Id == id);
                if (searchDepartment == null)
                {
                    return NotFound();
                }
                bool isDeleted = await _departmentManager.DeleteAsync(searchDepartment);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
                return View(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
