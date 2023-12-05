using EF.Core.Repository.Repository;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Repository;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Repository
{
    public class ResultRepository:CommonRepository<Result>,IResultRepository
    {
        public ResultRepository(UniversityMSDbContext db):base(db)
        {
            
        }
    }
}
