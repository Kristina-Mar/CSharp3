namespace ToDoList.Test;

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

public class DeleteTests
{
    [Fact]
    public void Delete_OneItemById_DeletesItem()
    {
        // Arrange
        var controller = new ToDoItemsController();
        controller.items.Clear();
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
    public void Delete_OneItemById_ReturnsNotFound()
    {
        // Arrange
        var controller = new ToDoItemsController();
        controller.items.Clear();
        var toDoItem = new ToDoItem // only works if items is public
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
        Assert.Single(controller.items);
    }
}
