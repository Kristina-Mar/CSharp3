namespace ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

public record class ToDoItemCreateRequestDto(string Name, string? Category, string Description, bool IsCompleted) //id is generated
{
    public ToDoItem ToDomain() => new() { Name = Name, Category = Category, Description = Description, IsCompleted = IsCompleted };
}
