namespace ToDoList.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    void Create(T item);
    public T? ReadById(int toDoItemId);
    public IEnumerable<T> Read();
    public bool UpdateById(T updatedItem);
    public bool DeleteById(int toDoItemId);
}
