using EF.Core.Repository.Manager;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Repository;

namespace UniversityManagementSystem.Manager
{
    public class EnrollManager : CommonManager<Enroll>, IEnrollManager
    {
        public EnrollManager(UniversityMSDbContext _db) : base(new EnrollRepository(_db))
        {

        }

        public bool IsAlreadyEnrolled(int studentId, int courseId)
        {
            var enrolledStudent = GetFirstOrDefault(c => c.StudentId == studentId && c.CourseId == courseId);
            if (enrolledStudent == null)
            {
                return false;
            }
            return true;
        }
    }
}
