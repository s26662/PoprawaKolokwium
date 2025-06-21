namespace WebApplication1.Model.DTOs;

public class RecordDto
{
    public int Id { get; set; }
    public LanguageDto Language { get; set; }
    public TaskDto Task { get; set; }
    public StudentDto Student { get; set; }
    public int ExecutionTime { get; set; }
    public DateTime Created { get; set; }
}
