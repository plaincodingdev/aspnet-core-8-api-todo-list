
namespace aspnet_core_8_todo_list_api.DTOs.ToDo
{
  public class UpdateToDoDto
  {
    public string Name { get; set; } = "Default ToDo Name"; // Default name to be updated if necessary
    public bool IsDone { get; set; } = false; // Status to be updated
  }
}
