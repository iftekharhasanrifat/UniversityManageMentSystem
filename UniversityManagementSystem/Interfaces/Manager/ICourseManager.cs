using EF.Core.Repository.Interface.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Interfaces.Manager
{
    public interface ICourseManager:ICommonManager<Course>
    {
        bool IsCourseExist(Course course);

    }
}
