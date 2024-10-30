namespace ToDoList.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    void Create(T item);
    public T ReadById(int id);
}
