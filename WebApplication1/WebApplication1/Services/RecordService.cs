using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Model;
using WebApplication1.Model.DTOs;

namespace WebApplication1.Services;

public interface IRecordService
{
    Task<IEnumerable<RecordDto>> GetRecordsAsync(int? languageId, int? taskId, DateTime? fromDate, DateTime? toDate);
    Task<(bool Success, string Message)> CreateRecordAsync(CreateRecordRequestDto request);
}

public class RecordService : IRecordService
{
    private readonly ExamDbContext _context;

    public RecordService(ExamDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RecordDto>> GetRecordsAsync(int? languageId, int? taskId, DateTime? from, DateTime? to)
    {
        var query = _context.Records
            .Include(r => r.Language)
            .Include(r => r.Task)
            .Include(r => r.Student)
            .AsQueryable();

        if (languageId.HasValue)
            query = query.Where(r => r.IdLanguage == languageId);

        if (taskId.HasValue)
            query = query.Where(r => r.IdTask == taskId);

        if (from.HasValue)
            query = query.Where(r => r.CreatedAt >= from.Value);

        if (to.HasValue)
            query = query.Where(r => r.CreatedAt <= to.Value);

        return await query
            .OrderByDescending(r => r.CreatedAt)
            .ThenBy(r => r.Student.LastName)
            .Select(r => new RecordDto
            {
                Id = r.IdRecord,
                ExecutionTime = r.ExecutionTime,
                Created = r.CreatedAt,
                Language = new LanguageDto
                {
                    Id = r.Language.IdLanguage,
                    Name = r.Language.Name
                },
                Task = new TaskDto
                {
                    Id = r.Task.IdTask,
                    Name = r.Task.Name,
                    Description = r.Task.Description
                },
                Student = new StudentDto
                {
                    Id = r.Student.IdStudent,
                    FirstName = r.Student.FirstName,
                    LastName = r.Student.LastName,
                    Email = r.Student.Email
                }
            })
            .ToListAsync();
    }

    public async Task<(bool Success, string Message)> CreateRecordAsync(CreateRecordRequestDto request)
    {
        var student = await _context.Students.FindAsync(request.IdStudent);
        if (student == null)
            return (false, "Student not found");

        var language = await _context.Languages.FindAsync(request.IdLanguage);
        if (language == null)
            return (false, "Language not found");

        Model.Task task = null;

        if (request.Task?.Id != null)
        {
            task = await _context.Tasks.FindAsync(request.Task.Id.Value);
            if (task == null)
                return (false, "Task with given ID not found");
        }
        else if (!string.IsNullOrWhiteSpace(request.Task?.Name) && !string.IsNullOrWhiteSpace(request.Task.Description))
        {
            task = new Model.Task
            {
                Name = request.Task.Name,
                Description = request.Task.Description
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }
        else
        {
            return (false, "Either task ID or task name and description must be provided");
        }

        var record = new Record
        {
            IdStudent = request.IdStudent,
            IdLanguage = request.IdLanguage,
            IdTask = task.IdTask,
            ExecutionTime = request.ExecutionTime,
            CreatedAt = request.Created
        };

        _context.Records.Add(record);
        await _context.SaveChangesAsync();

        return (true, "Record created");
    }
}