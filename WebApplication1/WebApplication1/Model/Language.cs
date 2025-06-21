using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Language
{
    [Key]
    public int IdLanguage { get; set; }
    public string Name { get; set; }
}