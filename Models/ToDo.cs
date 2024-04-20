namespace aspnet_core_8_todo_list_api.Models;

public class ToDo
{
  public long Id { get; set; } = 1; // Unique identifier for the todo item
  public string Name { get; set; } = "Default ToDo Name"; // Descriptive name of the todo item
  public bool IsDone { get; set; } = false; // Status indicating whether the todo is completed
}