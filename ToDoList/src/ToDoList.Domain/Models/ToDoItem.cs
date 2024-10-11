namespace ToDoList.Domain.Models;

using ToDoList.Domain.DTOs;

public class ToDoItem
{
    public int ToDoItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}
