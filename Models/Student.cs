using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Student
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(5, 100, ErrorMessage = "Age must be between 5 and 100")]
        public int Age { get; set; }

        [StringLength(20, ErrorMessage = "Grade cannot be longer than 20 characters")]
        public string? Grade { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }
    }
}