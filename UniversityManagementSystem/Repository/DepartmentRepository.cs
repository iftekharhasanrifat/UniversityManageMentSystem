using EF.Core.Repository.Repository;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Repository;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Repository
{
    public class DepartmentRepository:CommonRepository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(UniversityMSDbContext db):base(db)
        {
            
        }
    }
}
