namespace ToDoList.Domain.DTOs;

using ToDoList.Domain.Models;

public record ToDoItemUpdateRequestDto(string Name, string Description, bool IsCompleted)
{
    public ToDoItem ToDomain() => new() { Name = Name, Description = Description, IsCompleted = IsCompleted };

    public static ToDoItemUpdateRequestDto FromDomain(ToDoItem item) => new(item.Name, item.Description, item.IsCompleted)
    {
        Name = item.Name,
        Description = item.Description,
        IsCompleted = item.IsCompleted
    };
}
