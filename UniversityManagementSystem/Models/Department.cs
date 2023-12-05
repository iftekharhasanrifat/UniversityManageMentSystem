using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(7,ErrorMessage = "code must be two  to seven characters long")]
        [MinLength(2, ErrorMessage = "code must be two  to seven characters long")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
