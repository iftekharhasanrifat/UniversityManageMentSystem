using EF.Core.Repository.Repository;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Repository;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Repository
{
    public class TeacherRepository:CommonRepository<Teacher>,ITeacherRepository
    {
        public TeacherRepository(UniversityMSDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
