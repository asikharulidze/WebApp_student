using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Student
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}