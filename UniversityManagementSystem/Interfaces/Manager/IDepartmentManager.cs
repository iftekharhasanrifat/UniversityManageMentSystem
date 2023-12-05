using EF.Core.Repository.Interface.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Interfaces.Manager
{
    public interface IDepartmentManager:ICommonManager<Department>
    {
        bool IsDepartmentExist(Department department);
    }
}
