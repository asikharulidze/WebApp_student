using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain.Entities;

public class Student
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required] [MinLength(9)]
    public string PhoneNumber { get; set; }
}