namespace ToDoList.Test;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.WebApi.Controllers;

[Collection("Tests")]
public class PostTests
{
    [Fact]
    public void Post_NewItem_CreatesItem()
    {
        // Arrange
        var controller = new ToDoItemsController();
        ToDoItemsController.items = [];
        var toDoItemDto = new ToDoItemCreateRequestDto("New item name", "New item description", false);

        // Act
        var result = controller.Create(toDoItemDto);

        // Assert
        var resultResult = Assert.IsType<CreatedAtActionResult>(result).Value;
        var newItem = resultResult as ToDoItemGetResponseDto;
        Assert.NotNull(ToDoItemsController.items.Find(i => i.Name == toDoItemDto.Name));
        Assert.Single(ToDoItemsController.items);
        Assert.Equal(ToDoItemsController.items.Max(o => o.ToDoItemId), newItem.ToDoItemId);
        Assert.Equal(toDoItemDto.Name, newItem.Name);
        Assert.Equal(toDoItemDto.Description, newItem.Description);
        Assert.Equal(toDoItemDto.IsCompleted, newItem.IsCompleted);
    }
}
