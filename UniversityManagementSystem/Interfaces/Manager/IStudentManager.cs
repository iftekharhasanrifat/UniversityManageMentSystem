using EF.Core.Repository.Interface.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Interfaces.Manager
{
    public interface IStudentManager:ICommonManager<Student>
    {
        string GenerateRegistrationNumber(Student student);
        bool IsEmailExist(Student student);

    }
}
