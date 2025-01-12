using aspnet_core_8_todo_list_api.Models;

namespace aspnet_core_8_todo_list_api.Data;
public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Seed the database with migration
    modelBuilder.Entity<ToDo>().HasData(
      new ToDo { Id = 1, Name = "Do the dishes", IsDone = false },
      new ToDo { Id = 2, Name = "Walk the dog", IsDone = false },
      new ToDo { Id = 3, Name = "Buy groceries", IsDone = false }
    );
  }

  public DbSet<ToDo> ToDos { get; set; }
}
