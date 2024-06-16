using aspnet_core_8_todo_list_api.DTOs.ToDo;
using aspnet_core_8_todo_list_api.Models;

namespace aspnet_core_8_todo_list_api.Services.ToDoService;

public class ToDoService : IToDoService
{
  private List<ToDo> _toDos; // Store ToDos in memory

  public ToDoService()
  {
    // Initialize the list with a dummy ToDo 
    _toDos = new List<ToDo>
    {
        new ToDo { Id = 1, Name = "Do the dishes", IsDone = false }
    };
  }

  public ToDo AddToDo(AddToDoDto addToDo)
  {
    long newId = 0;
    if (_toDos.Count > 0)
    {
      newId = _toDos.Max(toDo => toDo.Id) + 1;
    }

    var newToDo = new ToDo
    {
      Id = newId,
      Name = addToDo.Name,
      IsDone = false
    };

    _toDos.Add(newToDo);

    return newToDo;
  }

  public ToDo GetToDo(long id)
  {
    return _toDos.FirstOrDefault(toDo => toDo.Id == id);
  }

  public List<ToDo> GetToDos()
  {
    return _toDos;
  }

  public void DeleteToDo(long id)
  {
    var toDo = GetToDo(id);
    if (toDo != null)
    {
      _toDos.Remove(toDo);
    }
  }

  public void UpdateToDo(long id, UpdateToDoDto updatedToDo)
  {
    var existingToDo = GetToDo(id);
    if (existingToDo != null)
    {
      existingToDo.Name = updatedToDo.Name;
      existingToDo.IsDone = updatedToDo.IsDone;
    }
  }
}


