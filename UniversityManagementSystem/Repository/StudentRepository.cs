using EF.Core.Repository.Repository;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Repository;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Repository
{
    public class StudentRepository:CommonRepository<Student>,IStudentRepository
    {
        public StudentRepository(UniversityMSDbContext db):base(db)
        {
                
        }
    }
}
