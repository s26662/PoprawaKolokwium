using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Language
{
    [Key]
    public int IdLanguage { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    public ICollection<Record> Records { get; set; }
}