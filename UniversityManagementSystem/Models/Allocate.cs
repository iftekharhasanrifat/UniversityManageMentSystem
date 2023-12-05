using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    public class Allocate
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [ForeignKey(nameof(CourseId))]
        [Required]
        [Display(Name ="Room No.")]
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        [ForeignKey(nameof(RoomId))]
        [Required]
        [Display(Name ="Day")]
        public int DayId { get; set; }
        public Day? Day { get; set; }
        [ForeignKey(nameof(DayId))]
        [Required(ErrorMessage ="from time is required")]
        [Display(Name ="From")]
        public string FromTime { get; set; }
        [Required(ErrorMessage = "to time is required")]
        [Display(Name = "To")]
        public string ToTime { get; set; }

    }
}
