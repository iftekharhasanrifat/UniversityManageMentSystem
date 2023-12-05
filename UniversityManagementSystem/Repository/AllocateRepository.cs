using EF.Core.Repository.Repository;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Repository;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Repository
{
    public class AllocateRepository:CommonRepository<Allocate>,IAllocateRepository
    {
        public AllocateRepository(UniversityMSDbContext db):base(db)
        {
            
        }
    }
}
