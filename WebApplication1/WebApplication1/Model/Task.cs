using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Task
{
    [Key]
    public int IdTask { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    
    public ICollection<Record> Records { get; set; }
}