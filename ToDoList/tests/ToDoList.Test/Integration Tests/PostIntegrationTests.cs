namespace ToDoList.Test;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class PostIntegrationTests
{
    [Fact]
    public void Post_CreateValidRequest_ReturnsCreatedAtActionAndCreatesItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItemRequest = new ToDoItemCreateRequestDto("New test item name", "New test item description", false);

        // Act
        var result = controller.Create(toDoItemRequest);

        // Assert
        var resultResult = Assert.IsType<CreatedAtActionResult>(result).Value as ToDoItemGetResponseDto;

        var newItemId = repository.Read().Max(i => i.ToDoItemId);
        var newItemInDb = repository.ReadById(newItemId);

        Assert.Equal(toDoItemRequest.Name, newItemInDb.Name);
        Assert.Equal(toDoItemRequest.Description, newItemInDb.Description);
        Assert.Equal(toDoItemRequest.IsCompleted, newItemInDb.IsCompleted);

        Assert.Equal(newItemId, resultResult.ToDoItemId);
    }
}
