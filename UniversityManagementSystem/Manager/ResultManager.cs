using EF.Core.Repository.Manager;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Repository;

namespace UniversityManagementSystem.Manager
{
    public class ResultManager:CommonManager<Result>,IResultManager
    {
        public ResultManager(UniversityMSDbContext _db) :base(new ResultRepository(_db))
        {
            
        }

        public bool IsAlreadySaved(int studentId, int courseId)
        {
            var savedResult = GetFirstOrDefault(c => c.StudentId == studentId && c.CourseId == courseId);
            if (savedResult == null)
            {
                return false;
            }
            return true;
        }
    }
}
