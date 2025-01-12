using aspnet_core_8_todo_list_api.DTOs.ToDo;
using aspnet_core_8_todo_list_api.Models;

namespace aspnet_core_8_todo_list_api.Services.ToDoService;

public class ToDoService : IToDoService
{
  private List<ToDo> _toDos; // Store ToDos in memory
  private DataContext _context; // Store ToDos in database

  public ToDoService(DataContext context)
  {
    _context = context;

    // Initialize the list with a dummy ToDo 
    // _toDos = new List<ToDo>
    // {
    //     new ToDo { Id = 1, Name = "Do the dishes", IsDone = false }
    // };
  }

  public async Task<ToDo> AddToDo(AddToDoDto addToDo)
  {
    // long newId = 0;
    // if (_toDos.Count > 0)
    // {
    //   newId = _toDos.Max(toDo => toDo.Id) + 1;
    // }
    // var newToDo = new ToDo
    // {
    //   Id = newId,
    //   Name = addToDo.Name,
    //   IsDone = false
    // };
    // _toDos.Add(newToDo);
    // return newToDo;

    var newToDo = new ToDo
    {
      Name = addToDo.Name,
      IsDone = false
    };
    _context.ToDos.Add(newToDo);
    await _context.SaveChangesAsync();
    var latestToDo = await _context.ToDos.OrderByDescending(toDo => toDo.Id).FirstOrDefaultAsync();
    return latestToDo;
  }

  public async Task<ToDo> GetToDo(long id)
  {
    // return _toDos.FirstOrDefault(toDo => toDo.Id == id);
    var toDo = await _context.ToDos.FirstOrDefaultAsync(toDo => toDo.Id == id);
    return toDo;
  }

  public async Task<List<ToDo>> GetToDos()
  {
    // return _toDos;
    var toDos = await _context.ToDos.ToListAsync();
    return toDos;
  }

  public async Task DeleteToDo(long id)
  {
    var toDo = await GetToDo(id);
    if (toDo != null)
    {
      // _toDos.Remove(toDo);
      _context.ToDos.Remove(toDo);
      await _context.SaveChangesAsync();
    }
  }

  public async Task UpdateToDo(long id, UpdateToDoDto updatedToDo)
  {
    var existingToDo = await GetToDo(id);
    if (existingToDo != null)
    {
      existingToDo.Name = updatedToDo.Name;
      existingToDo.IsDone = updatedToDo.IsDone;
      await _context.SaveChangesAsync();
    }
  }
}


