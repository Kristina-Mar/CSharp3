namespace ToDoList.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    public void Create(T item);
    public T? ReadById(int toDoItemId);
    public IEnumerable<T> Read();
    public bool UpdateById(T updatedItem);
    public bool DeleteById(int toDoItemId);
}

public interface IRepositoryAsync<T> where T : class
{
    public Task CreateAsync(T item);
    public Task<T?> ReadByIdAsync(int toDoItemId);
    public Task<IEnumerable<T>> ReadAsync();
    public Task<bool> IsUpdatedByIdAsync(T updatedItem);
    public Task<bool> IsDeletedByIdAsync(int toDoItemId);
}
