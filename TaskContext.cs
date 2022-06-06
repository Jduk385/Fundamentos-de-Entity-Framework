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
        List<Category> categoryInit = new List<Category>();
        categoryInit.Add(new Category{Id = Guid.Parse("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2ad1"), Name = "Actividades pendientes", Weight = 20});
        categoryInit.Add(new Category{Id = Guid.Parse("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2ad2"), Name = "Actividades personales", Weight = 50});

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.Id);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description).IsRequired(false);
            category.Property(p => p.Weight);

            category.HasData(categoryInit);
        });

        List<Task> taskInit = new List<Task>();
        taskInit.Add(new Task{Id = Guid.Parse("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2a10"), CategoryId = Guid.Parse("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2ad1"), Priority = Priority.Medium, Title = "Pago de servicios", CreateDate = DateTime.Now});
        taskInit.Add(new Task{Id = Guid.Parse("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2a11"), CategoryId = Guid.Parse("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2ad2"), Priority = Priority.Medium, Title = "Ver serie", CreateDate = DateTime.Now});

        modelBuilder.Entity<Task>(task => 
        {
            task.ToTable("Task");
            task.HasKey(p => p.Id);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description).IsRequired(false);
            task.Property(p => p.Priority);
            task.Property(p => p.CreateDate);
            task.Ignore(p => p.Summary); // Ignore se utiliza para que la propiedad no se mapee en la DB
        });

    }
}