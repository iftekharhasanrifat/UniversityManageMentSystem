using EF.Core.Repository.Manager;
using NuGet.DependencyResolver;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Repository;

namespace UniversityManagementSystem.Manager
{
    public class StudentManager:CommonManager<Student>,IStudentManager
    {
        IDepartmentManager _departmentManager;
        public StudentManager(UniversityMSDbContext _db, IDepartmentManager departmentManager) :base(new StudentRepository(_db))
        {
            _departmentManager = departmentManager;
        }

        public string GenerateRegistrationNumber(Student student)
        {
            // Assuming you have a database context to access records

            var year = student.RegistrationDate.Year;
            var searchDepartment = _departmentManager.GetFirstOrDefault(c=>c.Id == student.DepartmentId);
            var departmentYear = $"{searchDepartment.Code}-{year}";

            // Get the count of existing registrations for the department-year combination
            var count = GetAll(c=>c.Department).Count(s => s.Department.Code == searchDepartment.Code && s.RegistrationDate.Year == year) + 1;

            // Format the registration number
            var RegistrationNumber = $"{departmentYear}-{count:000}";
            return RegistrationNumber ;
        }

        public bool IsEmailExist(Student student)
        {
            Student searchStudent = GetFirstOrDefault(c => c.Email.ToLower() == student.Email.ToLower());
            if (searchStudent != null)
            {
                return true;
            }
            return false;
        }
    }
}
