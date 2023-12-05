using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    public class Result
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Student Reg. No.")]
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        [Required]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }
        [Required]
        [Display(Name = "Select Grade Letter")]
        public string Grade { get; set; }
    }
}
