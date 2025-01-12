using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aspnet_core_8_todo_list_api.Models;

public class ToDo
{
  [Column("id")]
  public long Id { get; set; } // Unique identifier for the todo item

  [Column("name")]
  [MaxLength(100)]
  public string Name { get; set; } // Descriptive name of the todo item

  [Column("is_done")]
  public bool IsDone { get; set; } // Status indicating whether the todo is completed
}