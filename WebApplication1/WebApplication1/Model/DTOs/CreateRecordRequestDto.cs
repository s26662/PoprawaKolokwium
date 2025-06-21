namespace WebApplication1.Model.DTOs;

public class CreateRecordRequestDto
{
    
    public int StudentId { get; set; }
    public int LanguageId { get; set; }
    public int TaskId { get; set; }
    public string Name { get; set; }
    public string TaskDescription { get; set; }
}