
namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

public class GetTests
{
    [Fact]
    public void Get_AllItems_ReturnsAllItems()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var toDoItem = new ToDoItem // only works if items is public
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };
        ToDoItemsController.items.Add(toDoItem);

        // Act
        var result = controller.Read();
        var resultResult = result.Result as OkObjectResult;
        var value = resultResult.Value as IEnumerable<ToDoItemGetResponseDto>;

        // Assert
        Assert.True(resultResult is OkObjectResult);
        Assert.IsType<OkObjectResult>(resultResult);
        Assert.NotNull(value);
        Assert.Single(value);
    }

    [Fact]
    public void Get_AllItems_ReturnsNotFound() // Only works if items isn't readonly in the controller!
    {
        // Arrange
        var controller = new ToDoItemsController();
        ToDoItemsController.items = null;

        // Act
        var result = controller.Read();
        var value = result.Value;
        var resultResult = result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(resultResult);
    }
}
