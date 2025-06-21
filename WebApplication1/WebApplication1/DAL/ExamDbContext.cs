using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using Task = WebApplication1.Model.Task;


namespace WebApplication1.DAL;

public class ExamDbContext : DbContext
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Record> Records { get; set; }
    protected ExamDbContext()
    {
    }

    public ExamDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Student
        modelBuilder.Entity<Student>().HasData(
            new Student { IdStudent = 1, FirstName = "Tomek", LastName = "Kowalski", Email = "tomcio@wp.pl" },
            new Student { IdStudent = 2, FirstName = "Ala", LastName = "Kowalska", Email = "aniaK@wp.pl" }
        );

        // Seed Language
        modelBuilder.Entity<Language>().HasData(
            new Language { IdLanguage = 1, Name = "C#" },
            new Language { IdLanguage = 2, Name = "Java" }
        );

        // Seed Task
        modelBuilder.Entity<Task>().HasData(
            new Task { IdTask = 1, Name = "Fizz-Buzz", Description = "Write a program that prints the numbers from 1 to 100." },
            new Task { IdTask = 2, Name = "Palindrome", Description = "Check if a string is a palindrome." }
        );

        // Seed Record
        modelBuilder.Entity<Record>().HasData(
            new Record { IdRecord = 1,IdStudent = 1, IdLanguage = 1, IdTask = 1, ExecutionTime = 1233, CreatedAt = DateTime.Parse("2015-05-29 05:50:06") },
            new Record { IdRecord = 2, IdStudent = 2, IdLanguage = 2, IdTask = 2, ExecutionTime = 874, CreatedAt = DateTime.Parse("2016-04-10 10:20:00") });
    }
}
