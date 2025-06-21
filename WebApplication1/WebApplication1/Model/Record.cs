using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model;

public class Record
{
    [Key]
    public int IdRecord { get; set; }
    public int ExecutionTime { get; set; }
    public DateTime CreatedAt { get; set; }
    
    [ForeignKey(nameof(Language))]
    public int IdLanguage { get; set; }
    public Language Language { get; set; }
    
    [ForeignKey(nameof(Student))]
    public int IdStudent { get; set; }
    public Student Student { get; set; }
    
    [ForeignKey(nameof(Task))]
    public int IdTask { get; set; }
    public Task Task { get; set; }
}