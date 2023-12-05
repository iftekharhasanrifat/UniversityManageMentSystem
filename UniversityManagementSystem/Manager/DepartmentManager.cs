using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Repository;

namespace UniversityManagementSystem.Manager
{
    public class DepartmentManager : CommonManager<Department>, IDepartmentManager
    {
        public DepartmentManager(UniversityMSDbContext _db) : base(new DepartmentRepository(_db))
        {

        }

        public bool IsDepartmentExist(Department department)
        {
            var searchDepartment = GetFirstOrDefault(c => c.Code.ToLower() == department.Code.ToLower() || c.Name.ToLower() == department.Name.ToLower());
            if (searchDepartment != null)
            {
                return true;
            }
            return false;
        }
    }
}
