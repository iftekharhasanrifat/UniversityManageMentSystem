using EF.Core.Repository.Repository;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Repository;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Repository
{
    public class EnrollRepository:CommonRepository<Enroll>,IEnrollRepository
    {
        public EnrollRepository(UniversityMSDbContext db):base(db)
        {
            
        }
    }
}
