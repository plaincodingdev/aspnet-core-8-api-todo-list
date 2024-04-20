using aspnet_core_8_todo_list_api.DTOs.ToDo;
using aspnet_core_8_todo_list_api.Models;

namespace aspnet_core_8_todo_list_api.Services.ToDoService;

public interface IToDoService
{
  ToDo AddToDo(AddToDoDto addToDo);
  ToDo GetToDo(long id);
  List<ToDo> GetToDos();
  void DeleteToDo(long id);
  void UpdateToDo(long id, UpdateToDoDto updateToDo);
}
