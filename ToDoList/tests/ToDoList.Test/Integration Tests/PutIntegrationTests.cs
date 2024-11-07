namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class PutIntegrationTests
{
    [Fact]
    public void Put_ValidId_UpdatesItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItem = new ToDoItem()
        {
            Name = "Put test name",
            Description = "Put test description",
            IsCompleted = false
        };
        context.Add(toDoItem);
        context.SaveChanges();

        var updatedItem = new ToDoItemUpdateRequestDto("Updated name", "Updated description", true);

        // Act
        var result = controller.UpdateById(toDoItem.ToDoItemId, updatedItem);
        var updatedItemInList = repository.ReadById(toDoItem.ToDoItemId);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.Equal(updatedItem.Name, updatedItemInList.Name);
        Assert.Equal(updatedItem.Description, updatedItemInList.Description);
        Assert.Equal(updatedItem.IsCompleted, updatedItemInList.IsCompleted);
    }

    [Fact]
    public void Put_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        int invalidId = -1;
        var updatedItem = new ToDoItemUpdateRequestDto("Updated name", "Updated description", true);

        // Act
        var result = controller.UpdateById(invalidId, updatedItem);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        Assert.Null(repository.ReadById(invalidId));
    }
}
