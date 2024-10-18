
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
        var result = controller.Read();

        // Assert
        //Assert.True(result.Result is OkObjectResult);
        var resultResult = Assert.IsType<OkObjectResult>(result.Result);

        var value = resultResult.Value as IEnumerable<ToDoItemGetResponseDto>;

        Assert.NotNull(value);
        Assert.Single(value);
        Assert.Equal(ToDoItemGetResponseDto.FromDomain(toDoItem), value.ToList()[0]);
    }

    [Fact]
    public void Get_AllItems_ReturnsNotFound()
    {
        // Arrange
        var controller = new ToDoItemsController();
        ToDoItemsController.items = null;

        // Act
        var result = controller.Read();
        var resultResult = result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(resultResult);
    }

    [Fact]
    public void Get_OneItemByID_ReturnsItem()
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
        var result = controller.ReadById(1);

        // Assert
        var resultResult = Assert.IsType<OkObjectResult>(result.Result);
        var value = resultResult.Value as ToDoItemGetResponseDto;
        Assert.NotNull(value);
        Assert.Equal(ToDoItemGetResponseDto.FromDomain(toDoItem), value);
    }

    [Fact]
    public void Get_OneItemByID_ReturnsNotFound()
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
        var result = controller.ReadById(2);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
        Assert.DoesNotContain(ToDoItemsController.items, i => i.ToDoItemId == 2);
    }
}
