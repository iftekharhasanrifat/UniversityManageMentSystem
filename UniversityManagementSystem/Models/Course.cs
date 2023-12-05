using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Course code must be at least five characters long.")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.5, 5.0, ErrorMessage = "credit cannot be less than 0.5 and more than 5.0.")]
        public decimal Credit { get; set; }
        public string? Description { get; set; }
        [Required]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [Required]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; } 
        [ForeignKey(nameof(SemesterId))]
        public Semester? Semester { get; set; }
        public int? TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher? Teacher { get; set; }
    }
}
