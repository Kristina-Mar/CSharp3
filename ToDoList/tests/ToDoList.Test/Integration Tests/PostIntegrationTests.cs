namespace ToDoList.Test;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class PostIntegrationTests
{
   /* [Fact]
    public void Post_NewItem_CreatesItem()
    {
        // Arrange
        var context = new ToDoItemsContext();
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItemDto = new ToDoItemCreateRequestDto("New test item name", "New test item description", false);

        // Act
        var result = controller.Create(toDoItemDto);

        // Assert
        var resultResult = Assert.IsType<CreatedAtActionResult>(result).Value;
        var newItem = resultResult as ToDoItemGetResponseDto;

        Assert.Equal(toDoItemDto.Name, newItem.Name);
        Assert.Equal(toDoItemDto.Description, newItem.Description);
        Assert.Equal(toDoItemDto.IsCompleted, newItem.IsCompleted);

        Assert.NotNull(context.ToDoItems.First(i => i.Name == toDoItemDto.Name));
        Assert.Equal(context.ToDoItems.Max(o => o.ToDoItemId), newItem.ToDoItemId);
    }*/
}
