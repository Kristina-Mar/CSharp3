namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

public class PutTests
{
    [Fact]
    public void Put_OneItemById_UpdatesItem()
    {
        // Arrange
        var controller = new ToDoItemsController();
        controller.items = [];
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };
        controller.items.Add(toDoItem);

        var updatedItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Updated name",
            Description = "Updated description",
            IsCompleted = true
        };

        // Act
        var result = controller.UpdateById(1, ToDoItemUpdateRequestDto.FromDomain(updatedItem));
        var updatedItemInList = controller.items.Find(i => i.ToDoItemId == 1);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.Equal(updatedItem.ToDoItemId, updatedItemInList.ToDoItemId);
        Assert.Equal(updatedItem.Name, updatedItemInList.Name);
        Assert.Equal(updatedItem.Description, updatedItemInList.Description);
        Assert.Equal(updatedItem.IsCompleted, updatedItemInList.IsCompleted);
    }

    [Fact]
    public void Put_OneItemById_ReturnsNotFound()
    {
        // Arrange
        var controller = new ToDoItemsController();
        controller.items = [];
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };
        controller.items.Add(toDoItem);

        var updatedItem = new ToDoItem
        {
            ToDoItemId = 2,
            Name = "Updated name",
            Description = "Updated description",
            IsCompleted = true
        };

        // Act
        var result = controller.UpdateById(2, ToDoItemUpdateRequestDto.FromDomain(updatedItem));

        // Assert
        Assert.IsType<NotFoundResult>(result);
        Assert.True(controller.items.Find(i => i.ToDoItemId == 2) == null);
    }
}
