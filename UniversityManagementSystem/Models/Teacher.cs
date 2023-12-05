using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Please enter a valid email adress")]
        public string Email { get; set; }
        [Required]
        [StringLength(11,MinimumLength =11,ErrorMessage ="Please enter a valid phone number")]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        public Designation? Designation { get; set; }
        [ForeignKey(nameof(DesignationId))]
        [Required]
        [Display(Name = "Credits to be taken")]
        [Range(0.0, double.PositiveInfinity, ErrorMessage = "Value should be greater than or equal to 0")]
        public double CreditsToBeTaken { get; set; }
        public double? RemainingCredit { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
