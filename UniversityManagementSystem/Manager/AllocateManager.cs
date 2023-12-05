using EF.Core.Repository.Manager;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Repository;

namespace UniversityManagementSystem.Manager
{
    public class AllocateManager : CommonManager<Allocate>, IAllocateManager
    {
        public AllocateManager(UniversityMSDbContext _db) : base(new AllocateRepository(_db))
        {

        }

        public bool IsAllocated(Allocate allocate)
        {
            string format = "h:mm tt";
            TimeSpan fromTimeSpan = DateTime.ParseExact(allocate.FromTime, format, System.Globalization.CultureInfo.InvariantCulture).TimeOfDay;
            TimeSpan toTimeSpan = DateTime.ParseExact(allocate.ToTime, format, System.Globalization.CultureInfo.InvariantCulture).TimeOfDay;

            var allocated = GetFirstOrDefault(c => c.DayId == allocate.DayId && c.RoomId == allocate.RoomId);
            if (allocated != null)
            {
                TimeSpan fromTime = DateTime.ParseExact(allocated.FromTime, format, System.Globalization.CultureInfo.InvariantCulture).TimeOfDay;
                TimeSpan toTime = DateTime.ParseExact(allocated.ToTime, format, System.Globalization.CultureInfo.InvariantCulture).TimeOfDay;
                // Check for overlap
                if (fromTime < toTimeSpan && toTime > fromTimeSpan)
                {
                    // There is an overlap
                    return true;
                }

            }
            return false;
        }
    }
}
