using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Models
{
    public class EnrollCourseVm
    {
        [Required]
        [Display(Name="Student Reg. No.")]
        public int StudentId { get; set; }
        public string Name { get; set;}
        public string Email { get; set; }
        public string Department { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
