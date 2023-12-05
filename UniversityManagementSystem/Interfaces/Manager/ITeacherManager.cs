using EF.Core.Repository.Interface.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Interfaces.Manager
{
    public interface ITeacherManager:ICommonManager<Teacher>
    {
        bool IsEmailExist(Teacher teacher);
    }
}
