using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Models
{
    public class AssignCourseVM
    {
        [Required]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Teacher")]

        public int TeacherId { get; set; }
        public double CreditsToBeTaken { get; set; }

        public double RemainingCredit { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double CourseCredit { get; set; }

    }
}
