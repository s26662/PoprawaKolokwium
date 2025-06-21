using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
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

    public async Task<IEnumerable<RecordDto>> GetRecordsAsync(int? languageId, int? taskId, DateTime? fromDate, DateTime? toDate)
    {
        var query = _context.Records
            .Include(r => r.Student)
            .Include(r => r.Language)
            .Include(r => r.Task)
            .AsQueryable();

        if (languageId.HasValue)
            query = query.Where(r => r.IdLanguage == languageId);
        if (taskId.HasValue)
            query = query.Where(r => r.IdTask == taskId);
        if (fromDate.HasValue)
            query = query.Where(r => r.CreatedAt >= fromDate.Value);
        if (toDate.HasValue)
            query = query.Where(r => r.CreatedAt <= toDate.Value);

        return await query
            .OrderByDescending(r => r.CreatedAt)
            .ThenBy(r => r.Student.LastName)
            .Select(r => new RecordDto()
            {
                RecordId = r.IdRecord,
                StudentName = $"{r.Student.FirstName} {r.Student.LastName}",
                Language = r.Language.Name,
                Title = r.Task.Name,
                CreatedAt = r.CreatedAt
            }).ToListAsync();
    }

    public Task<(bool Success, string Message)> CreateRecordAsync(CreateRecordRequestDto request)
    {
        throw new NotImplementedException();
    }
}