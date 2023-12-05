using EF.Core.Repository.Interface.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Interfaces.Manager
{
    public interface IResultManager:ICommonManager<Result>
    {
        bool IsAlreadySaved(int studentId, int courseId);
    }
}
