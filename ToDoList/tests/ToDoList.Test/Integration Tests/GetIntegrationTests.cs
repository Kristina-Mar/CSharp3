
namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class GetIntegrationTests
{
    [Fact]
    public void Get_AllItems_ReturnsAllItems()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItemDto = new ToDoItemCreateRequestDto("Test name", "Test description", false);
        controller.Create(toDoItemDto);

        // Act
        var result = controller.Read();

        // Assert
        //Assert.True(result.Result is OkObjectResult);
        var resultResult = Assert.IsType<OkObjectResult>(result.Result);

        var value = resultResult.Value as IEnumerable<ToDoItemGetResponseDto>;

        Assert.NotNull(value);
    }

    /*[Fact]
    public void Get_AllItemsWhenNull_ReturnsNotFound()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        // Act
        var result = controller.Read();
        var resultResult = result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(resultResult);
    }*/

    [Fact]
    public void Get_ValidId_ReturnsItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItemDto = new ToDoItemCreateRequestDto("Get test name", "Get test description", false);
        controller.Create(toDoItemDto);
        var newItemId = repository.Read().Max(i => i.ToDoItemId);
        var newItemInDb = repository.ReadById(newItemId);

        // Act
        var result = controller.ReadById(newItemId);

        // Assert
        var resultResult = Assert.IsType<OkObjectResult>(result.Result);
        var value = resultResult.Value as ToDoItemGetResponseDto;
        Assert.NotNull(value);
        Assert.Equal(newItemInDb.Name, value.Name);
        Assert.Equal(newItemInDb.Description, value.Description);
        Assert.Equal(newItemInDb.IsCompleted, value.IsCompleted);
    }

    [Fact]
    public void Get_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);
        int invalidId = -1;

        // Act
        var result = controller.ReadById(invalidId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
        Assert.Null(repository.ReadById(invalidId));
    }
}
