using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Student
{
    [Key]
    public int IdStudent { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(250)]
    public string Email { get; set; }
    
    public ICollection<Record> Records { get; set; }
}