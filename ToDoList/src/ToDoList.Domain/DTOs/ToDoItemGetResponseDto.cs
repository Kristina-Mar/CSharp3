namespace ToDoList.Domain.DTOs;

using System.Security.Cryptography.X509Certificates;
using ToDoList.Domain.Models;


public record class ToDoItemGetResponseDto
{
    public int ToDoItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public static ToDoItemGetResponseDto ToDomain(ToDoItem item) => new()
    {
        ToDoItemId = item.ToDoItemId,
        Name = item.Name,
        Description = item.Description,
        IsCompleted = item.IsCompleted
    };
}
