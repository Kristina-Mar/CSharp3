using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

namespace ToDoList.Test;

public class PostTests
{
    [Fact]
    public void Post_NewItem_CreatesItem()
    {
        // Arrange
        var controller = new ToDoItemsController();
        controller.items = [];
        var toDoItemDto = new ToDoItemCreateRequestDto("New item name", "New item description", false);

        // Act
        var result = controller.Create(toDoItemDto);

        // Assert
        var resultResult = Assert.IsType<CreatedAtActionResult>(result).Value;

        var newItem = resultResult as ToDoItemGetResponseDto;
        Assert.NotNull(controller.items.Find(i => i.Name == toDoItemDto.Name));
        Assert.Equal(controller.items.Max(o => o.ToDoItemId), newItem.ToDoItemId);
        Assert.Equal(toDoItemDto.Name, newItem.Name);
        Assert.Equal(toDoItemDto.Description, newItem.Description);
        Assert.Equal(toDoItemDto.IsCompleted, newItem.IsCompleted);
    }
}
