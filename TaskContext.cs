using Microsoft.EntityFrameworkCore;
using projectEF.Models;
using Task = projectEF.Models.Task;

namespace projectEF;

public class TaskContext : DbContext
{
    DbSet<Category> Categories {get; set;}
    DbSet<Models.Task> Tasks {get; set;}

    public TaskContext(DbContextOptions<TaskContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.Id);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description);
        });

        modelBuilder.Entity<Task>(task => 
        {
            task.ToTable("Task");
            task.HasKey(p => p.Id);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description);
            task.Property(p => p.Priority);
            task.Property(p => p.CreateDate);
            task.Ignore(p => p.Summary); // Ignore se utiliza para que la propiedad no se mapee en la DB
        });

    }
}