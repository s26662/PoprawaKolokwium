using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using Task = WebApplication1.Model.Task;


namespace WebApplication1.DAL;

public class ExamDbContext : DbContext
{
    DbSet<Language> Languages { get; set; }
    DbSet<Task> Tasks { get; set; }
    protected ExamDbContext()
    {
    }

    public ExamDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //seeds
    }

}