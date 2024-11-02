namespace ToDoList.Test;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Persistence;
using ToDoList.WebApi.Controllers;

public class PostTests
{
    /*[Fact]
    public void Post_NewItem_CreatesItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var controller = new ToDoItemsController(context);
        controller.items = [];
        var toDoItemDto = new ToDoItemCreateRequestDto("New item name", "New item description", false);

        // Act
        var result = controller.Create(toDoItemDto);

        // Assert
        var resultResult = Assert.IsType<CreatedAtActionResult>(result).Value;
        var newItem = resultResult as ToDoItemGetResponseDto;
        Assert.NotNull(controller.items.Find(i => i.Name == toDoItemDto.Name));
        Assert.Single(controller.items);
        Assert.Equal(controller.items.Max(o => o.ToDoItemId), newItem.ToDoItemId);
        Assert.Equal(toDoItemDto.Name, newItem.Name);
        Assert.Equal(toDoItemDto.Description, newItem.Description);
        Assert.Equal(toDoItemDto.IsCompleted, newItem.IsCompleted);
    }*/
}
