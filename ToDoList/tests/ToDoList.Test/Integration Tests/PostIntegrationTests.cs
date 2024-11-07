namespace ToDoList.Test;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class PostIntegrationTests
{
    [Fact]
    public void Post_NewItem_CreatesItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItemDto = new ToDoItemCreateRequestDto("New test item name", "New test item description", false);

        // Act
        var result = controller.Create(toDoItemDto);

        // Assert
        var resultResult = Assert.IsType<CreatedAtActionResult>(result).Value as ToDoItemGetResponseDto;

        var newItemId = repository.Read().Max(i => i.ToDoItemId);
        var newItemInDb = repository.ReadById(newItemId);

        Assert.Equal(toDoItemDto.Name, newItemInDb.Name);
        Assert.Equal(toDoItemDto.Description, newItemInDb.Description);
        Assert.Equal(toDoItemDto.IsCompleted, newItemInDb.IsCompleted);

        Assert.Equal(newItemId, resultResult.ToDoItemId);
    }
}
