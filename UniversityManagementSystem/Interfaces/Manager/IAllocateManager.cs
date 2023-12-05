using EF.Core.Repository.Interface.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Interfaces.Manager
{
    public interface IAllocateManager:ICommonManager<Allocate>
    {
        bool IsAllocated(Allocate allocate);
    }
}
