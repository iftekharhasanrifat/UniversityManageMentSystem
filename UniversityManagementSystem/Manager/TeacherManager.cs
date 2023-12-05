using EF.Core.Repository.Manager;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Repository;

namespace UniversityManagementSystem.Manager
{
    public class TeacherManager : CommonManager<Teacher>, ITeacherManager
    {
        public TeacherManager(UniversityMSDbContext _dbContext) : base(new TeacherRepository(_dbContext))
        {

        }

        public bool IsEmailExist(Teacher teacher)
        {
            Teacher seacrhTeacher = GetFirstOrDefault(c => c.Email.ToLower() == teacher.Email.ToLower());
            if (seacrhTeacher != null)
            {
                return true;
            }
            return false;
        }
    }
}
