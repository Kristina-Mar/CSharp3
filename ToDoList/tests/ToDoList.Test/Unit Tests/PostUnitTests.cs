namespace ToDoList.Test;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using NSubstitute;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using Microsoft.AspNetCore.Http;

public class PostUnitTests
{
    [Fact]
    public void Post_ValidRequest_CreatesItem()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var toDoItemRequestDto = new ToDoItemCreateRequestDto("New item name", "New item description", false);

        var toDoItemReturnedDtoExpected = new ToDoItemGetResponseDto
        {
            ToDoItemId = 1,
            Name = "New item name",
            Description = "New item description",
            IsCompleted = false
        };

        repositoryMock.When(r => r.Create(Arg.Any<ToDoItem>())).Do(callInfo =>
        {
            var item = callInfo.Arg<ToDoItem>();
            item.ToDoItemId = 1;
        });

        // Act
        var result = controller.Create(toDoItemRequestDto);

        // Assert
        var resultResult = Assert.IsType<CreatedAtActionResult>(result).Value;
        var newItem = resultResult as ToDoItemGetResponseDto;

        Assert.Equal(toDoItemReturnedDtoExpected.ToDoItemId, newItem.ToDoItemId);
        Assert.Equal(toDoItemReturnedDtoExpected.Name, newItem.Name);
        Assert.Equal(toDoItemReturnedDtoExpected.Description, newItem.Description);
        Assert.Equal(toDoItemReturnedDtoExpected.IsCompleted, newItem.IsCompleted);
    }

    [Fact]
    public void Post_UnhandledException_Returns500()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var toDoItemDto = new ToDoItemCreateRequestDto("New item name", "New item description", false);

        repositoryMock.When(r => r.Create(Arg.Any<ToDoItem>())).Do(r => throw new Exception());

        // Act
        var result = controller.Create(toDoItemDto);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
    }
}
