using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    public class Enroll
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        [ForeignKey(nameof(StudentId))]
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [ForeignKey(nameof(CourseId))]
        public DateTime Date { get; set; }
        public string? Grade { get; set; }
    }
}
