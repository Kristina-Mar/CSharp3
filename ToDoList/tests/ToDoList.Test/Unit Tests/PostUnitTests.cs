namespace ToDoList.Test;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using NSubstitute;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;

public class PostUnitTests
{
    [Fact]
    public void Post_NewItem_CreatesItem()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var toDoItemDto = new ToDoItemCreateRequestDto("New item name", "New item description", false);

        repositoryMock.When(r => r.Create(Arg.Any<ToDoItem>())).Do(r => throw new Exception());

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
