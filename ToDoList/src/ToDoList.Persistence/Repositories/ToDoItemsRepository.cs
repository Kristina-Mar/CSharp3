namespace ToDoList.Persistence.Repositories;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;

public class ToDoItemsRepository : IRepositoryAsync<ToDoItem>
{
    private readonly ToDoItemsContext context;

    public ToDoItemsRepository(ToDoItemsContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(ToDoItem item)
    {
        await context.ToDoItems.AddAsync(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<ToDoItem>> ReadAsync()
    {
        return await context.ToDoItems.ToListAsync();
    }

    public async Task<ToDoItem> ReadByIdAsync(int toDoItemId)
    {
        return await context.ToDoItems.FindAsync(toDoItemId);
    }

    public async Task<bool> UpdateByIdAsync(ToDoItem updatedItem)
    {
        var itemToUpdateInDb = await context.ToDoItems.FindAsync(updatedItem.ToDoItemId);
        if (itemToUpdateInDb == null)
        {
            return false;
        }
        context.Entry(itemToUpdateInDb).CurrentValues.SetValues(updatedItem);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int toDoItemId)
    {
        var itemToDeleteInDb = await context.ToDoItems.FindAsync(toDoItemId);
        if (itemToDeleteInDb == null)
        {
            return false;
        }

        context.ToDoItems.Remove(itemToDeleteInDb);
        await context.SaveChangesAsync();
        return true;
    }
}
