using aspnet_core_8_todo_list_api.DTOs.ToDo;
using aspnet_core_8_todo_list_api.Models;

namespace aspnet_core_8_todo_list_api.Services.ToDoService;

public interface IToDoService
{
  Task<ToDo> AddToDo(AddToDoDto addToDo);
  Task<ToDo> GetToDo(long id);
  Task<List<ToDo>> GetToDos();
  Task DeleteToDo(long id);
  Task UpdateToDo(long id, UpdateToDoDto updateToDo);
}
