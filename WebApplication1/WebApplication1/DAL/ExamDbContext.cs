using Microsoft.EntityFrameworkCore;


namespace WebApplication1.DAL;

public class ExamDbContext : DbContext
{
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