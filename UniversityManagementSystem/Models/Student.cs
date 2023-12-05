using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email adress")]
        public string Email { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Please enter a valid phone number")]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        
        public string? RegistrationNumber { get; set; }

    }
}
