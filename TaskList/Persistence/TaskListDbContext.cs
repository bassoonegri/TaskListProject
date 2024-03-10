using Microsoft.EntityFrameworkCore;

namespace TaskListProject.Persistence;

public class TaskListDbContext : DbContext
{
    public TaskListDbContext(DbContextOptions<TaskListDbContext> options) : base(options)
    {

    }

    public DbSet<Entities.TaskList> TaskList { get; set; }
}
