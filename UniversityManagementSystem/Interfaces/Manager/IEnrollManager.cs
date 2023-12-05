using EF.Core.Repository.Interface.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Interfaces.Manager
{
    public interface IEnrollManager:ICommonManager<Enroll>
    {
        bool IsAlreadyEnrolled(int studentId, int courseId);
    }
}
