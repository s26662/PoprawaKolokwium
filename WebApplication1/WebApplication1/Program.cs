using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        //Scope
        builder.Services.AddScoped<IRecordService, RecordService>();
        
        string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ExamDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        //builder.Services.AddScoped<IRecordService, RecordService>();

        app.UseHttpsRedirection();
        
        app.UseAuthentication();

        app.MapControllers();

        app.Run();
    }
}