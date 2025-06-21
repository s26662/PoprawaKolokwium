using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Task
{
    [Key]
    public int IdTask { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}