namespace WebApplication1.Model.DTOs;

public class CreateRecordRequestDto
{
    
    public int IdStudent { get; set; }
    public int IdLanguage { get; set; }
    public TaskDto Task { get; set; }
    public int ExecutionTime { get; set; }
    public DateTime Created { get; set; }
}

