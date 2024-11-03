namespace ToDoList.Persistence.Repositories;

using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

public interface IRepository<T> where T : class
{
    void Create(T item);
    public T ReadById(int toDoItemId);
    /*
    Toto je genericky repository interface, takze ToDoItem by sa tu nemalo vobec vyskytnut.
    Read by ti mal vracat List<T> a tvoja implementacia IRepository<T> ToDoItemsRepository teda bude vracat List<ToDoItem>, a nie List<ToDoItemGetResponseDto>
    ToDoItemGetResponseDto uz je response class, ktoru pouzivas az v prezentacnej (WebAPI projekt) vrstve, na databazovej (Persistence projekt) pozname iba ToDoItem class.
    Konverziu na ToDoItemGetResponseDto potom presun az do controlleru.
    */
    public List<ToDoItemGetResponseDto> Read();
    /*
    Ako pisem vyssie, ToDoItem nahradit T.
    */
    public bool UpdateById(int toDoItemId, ToDoItem updatedItem);
    public bool DeleteById(int toDoItemId);
}
