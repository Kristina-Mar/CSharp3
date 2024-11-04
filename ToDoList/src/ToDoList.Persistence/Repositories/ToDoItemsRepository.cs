namespace ToDoList.Persistence.Repositories;

using System.Collections.Generic;
using ToDoList.Domain.Models;

public class ToDoItemsRepository : IRepository<ToDoItem>
{
    private readonly ToDoItemsContext context;

    public ToDoItemsRepository(ToDoItemsContext context)
    {
        this.context = context;
    }
    public void Create(ToDoItem item)
    {
        context.ToDoItems.Add(item);
        context.SaveChanges();
    }

    public List<ToDoItem> Read()
    {
        return context.ToDoItems.ToList();
    }

    public ToDoItem ReadById(int toDoItemId)
    {
        return context.ToDoItems.Find(toDoItemId);
    }

    public bool UpdateById(int toDoItemId, ToDoItem updatedItem)
    {
        var itemToUpdateInDb = context.ToDoItems.Find(toDoItemId);
        if (itemToUpdateInDb == null)
        {
            return false;
        }

        itemToUpdateInDb.Name = updatedItem.Name;
        itemToUpdateInDb.Description = updatedItem.Description;
        itemToUpdateInDb.IsCompleted = updatedItem.IsCompleted;
        context.SaveChanges();
        return true;
    }

    public bool DeleteById(int toDoItemId)
    {
        var itemToDeleteInDb = context.ToDoItems.Find(toDoItemId);
        if (itemToDeleteInDb == null)
        {
            return false;
        }

        context.ToDoItems.Remove(itemToDeleteInDb);
        context.SaveChanges();
        return true;
    }
}
