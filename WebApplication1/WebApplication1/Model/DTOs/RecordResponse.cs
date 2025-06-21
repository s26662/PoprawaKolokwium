namespace WebApplication1.Model.DTOs;

public class RecordDto
{
    public int RecordId { get; set; }
    public string StudentName { get; set; }
    public string Language { get; set; }
    public string TaskTitle { get; set; }
    public DateTime CreatedAt { get; set; }
}