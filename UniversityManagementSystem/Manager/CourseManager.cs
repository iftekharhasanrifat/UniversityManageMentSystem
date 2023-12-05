using EF.Core.Repository.Manager;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Repository;

namespace UniversityManagementSystem.Manager
{
    public class CourseManager:CommonManager<Course>,ICourseManager
    {
        public CourseManager(UniversityMSDbContext _db):base(new CourseRepository(_db))
        {
            
        }

        public bool IsCourseExist(Course course)
        {
            var searchCourse = GetFirstOrDefault(c => c.Code.ToLower() == course.Code.ToLower() || c.Name.ToLower() == course.Name.ToLower());
            if (searchCourse != null)
            {
                return true;
            }
            return false;
        }
    }
}
