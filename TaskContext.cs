using Microsoft.EntityFrameworkCore;
using projectEF.Models;

namespace projectEF;

public class TaskContext : DbContext
{
    DbSet<Category> Categories {get; set;}
    DbSet<Models.Task> Tasks {get; set;}

    public TaskContext(DbContextOptions<TaskContext> options) : base(options) {}
}