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
  private readonly ILogger<ToDosController> _logger;

  public ToDosController(IToDoService toDoService, ILogger<ToDosController> logger)
  {
    _toDoService = toDoService; // Constructor injection to manage toDo
    _logger = logger; // Constructor injection to manage logging
  }

  // Get all ToDos
  [HttpGet]
  public async Task<ActionResult<IEnumerable<ToDo>>> GetToDos()
  {
    _logger.LogInformation("API: GetToDos called");
    return await _toDoService.GetToDos();
  }

  // Get a ToDo by id
  [HttpGet("{id}")]
  public async Task<ActionResult<ToDo>> GetToDo(long id)
  {
    _logger.LogInformation($"API: GetToDo called with id {id}");

    var toDo = await _toDoService.GetToDo(id);

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
    _logger.LogInformation($"API: AddToDo called with ToDo Name {addToDo.Name}");

    var toDo = await _toDoService.AddToDo(addToDo);

    return CreatedAtAction(nameof(AddToDo), new { id = toDo.Id }, toDo);
  }

  // Delete a ToDo by id
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteToDo(long id)
  {
    _logger.LogInformation($"API: DeleteToDo called with id {id}");

    var toDo = await _toDoService.GetToDo(id);

    if (toDo == null)
    {
      return NotFound();
    }

    await _toDoService.DeleteToDo(id);

    return NoContent();
  }

  // Update a ToDo by id
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateToDo(long id, UpdateToDoDto updateToDo)
  {
    _logger.LogInformation($"API: UpdateToDo called with id {id}");

    var existingToDo = await _toDoService.GetToDo(id);

    if (existingToDo == null)
    {
      return NotFound();
    }

    await _toDoService.UpdateToDo(id, updateToDo);

    return NoContent();
  }
}
