
namespace aspnet_core_8_todo_list_api.DTOs.ToDo
{
  public class AddToDoDto
  {
    public string Name { get; set; } = "Default ToDo Name"; // Initial default name for a new todo item
    public bool IsDone { get; set; } = false; // Initial status of the todo, default is not completed
  }
}
