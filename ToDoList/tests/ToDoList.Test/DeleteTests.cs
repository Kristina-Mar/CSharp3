namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

public class DeleteTests
{
    [Fact]
    public void Delete_OneItemById_DeletesItem()
    {
        // Arrange
        var controller = new ToDoItemsController();
        ToDoItemsController.items = [];
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
        ToDoItemsController.items.Add(toDoItem);
        ToDoItemsController.items.Add(toDoItem2);

        // Act
        var result = controller.DeleteById(2);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.DoesNotContain(ToDoItemsController.items, i => i.ToDoItemId == 2);
        Assert.Single(ToDoItemsController.items);
    }

    [Fact]
    public void Delete_OneItemById_ReturnsNotFound()
    {
        // Arrange
        var controller = new ToDoItemsController();
        ToDoItemsController.items = [];
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };
        ToDoItemsController.items.Add(toDoItem);

        // Act
        var result = controller.DeleteById(2);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        Assert.DoesNotContain(ToDoItemsController.items, i => i.ToDoItemId == 2);
        Assert.Single(ToDoItemsController.items);
    }
}
