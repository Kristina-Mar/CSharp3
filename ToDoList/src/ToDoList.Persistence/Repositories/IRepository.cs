namespace ToDoList.Persistence.Repositories;

using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

public interface IRepository<T> where T : class
{
    void Create(T item);
    public T ReadById(int toDoItemId);
    public List<ToDoItemGetResponseDto> Read();
    public bool UpdateById(int toDoItemId, ToDoItem updatedItem);
    public bool DeleteById(int toDoItemId);
}
