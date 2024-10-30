namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.WebApi.Controllers;

public class DeleteTests
{
    [Fact]
    public void Delete_ValiId_DeletesItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var controller = new ToDoItemsController(context);
        controller.items = [];
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };
        var toDoItem2 = new ToDoItem
        {
            ToDoItemId = 2,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };
        controller.items.Add(toDoItem);
        controller.items.Add(toDoItem2);

        // Act
        var result = controller.DeleteById(2);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.DoesNotContain(controller.items, i => i.ToDoItemId == 2);
        Assert.Single(controller.items);
    }

    [Fact]
    public void Delete_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var controller = new ToDoItemsController(context);
        controller.items = [];
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };
        controller.items.Add(toDoItem);

        // Act
        var result = controller.DeleteById(2);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        Assert.DoesNotContain(controller.items, i => i.ToDoItemId == 2);
        Assert.Single(controller.items);
    }
}
