using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Models
{
    public class CourseTeacherMapping
    {
        public string Code { get; set; }
        [Display(Name = "Name/Title")]
        public string Name { get; set; }
        [Display(Name = "Semester")]
        public string SemesterName { get; set; }
        [Display(Name = "Assign To")]
        public string AssignTo { get; set; }
    }
}
