using EF.Core.Repository.Repository;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Repository;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Repository
{
    public class CourseRepository:CommonRepository<Course>,ICourseRepository
    {
        public CourseRepository(UniversityMSDbContext db):base(db)
        {
            
        }
    }
}
