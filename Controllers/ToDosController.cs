using Microsoft.AspNetCore.Mvc;
using aspnet_core_8_todo_list_api.Models;
using aspnet_core_8_todo_list_api.Services.ToDoService;
using aspnet_core_8_todo_list_api.DTOs.ToDo;

namespace aspnet_core_8_todo_list_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDosController : ControllerBase
{
  private readonly IToDoService _toDoService;

  public ToDosController(IToDoService toDoService)
  {
    _toDoService = toDoService; // Constructor injection to manage toDo
  }

  // Get all ToDos
  [HttpGet]
  public async Task<ActionResult<IEnumerable<ToDo>>> GetToDos()
  {
    return _toDoService.GetToDos();
  }

  // Get a ToDo by id
  [HttpGet("{id}")]
  public async Task<ActionResult<ToDo>> GetToDo(long id)
  {
    var toDo = _toDoService.GetToDo(id);

    if (toDo == null)
    {
      return NotFound();
    }

    return toDo;
  }

  // Add a new ToDo
  [HttpPost]
  public async Task<ActionResult<ToDo>> AddToDo(AddToDoDto addToDo)
  {
    var toDo = _toDoService.AddToDo(addToDo);

    return CreatedAtAction(nameof(AddToDo), new { id = toDo.Id }, toDo);
  }

  // Delete a ToDo by id
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteToDo(long id)
  {
    var toDo = _toDoService.GetToDo(id);

    if (toDo == null)
    {
      return NotFound();
    }

    _toDoService.DeleteToDo(id);

    return NoContent();
  }

  // Update a ToDo by id
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateToDo(long id, UpdateToDoDto updateToDo)
  {
    var existingToDo = _toDoService.GetToDo(id);

    if (existingToDo == null)
    {
      return NotFound();
    }

    _toDoService.UpdateToDo(id, updateToDo);

    return NoContent();
  }
}
