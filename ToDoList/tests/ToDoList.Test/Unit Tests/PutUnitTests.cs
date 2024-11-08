namespace ToDoList.Test;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class PutUnitTests
{
    [Fact]
    public void Put_UpdateByIdWhenItemUpdated_ReturnsNoContent()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var updatedItem = new ToDoItemUpdateRequestDto("Updated name", "Updated description", true);

        repositoryMock.UpdateById(Arg.Any<ToDoItem>()).Returns(true);

        // Act
        var result = controller.UpdateById(1, updatedItem);

        // Assert
        Assert.IsType<NoContentResult>(result);
        repositoryMock.Received(1).UpdateById(Arg.Any<ToDoItem>());
    }

    [Fact]
    public void Put_UpdateByIdWhenIdNotFound_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var updatedItem = new ToDoItemUpdateRequestDto("Updated name", "Updated description", true);

        repositoryMock.UpdateById(Arg.Any<ToDoItem>()).Returns(false);

        // Act
        var result = controller.UpdateById(2, updatedItem);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        repositoryMock.Received(1).UpdateById(Arg.Any<ToDoItem>());
    }

    [Fact]
    public void Put_UpdateByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var updatedItem = new ToDoItemUpdateRequestDto("Updated name", "Updated description", true);

        repositoryMock.When(r => r.UpdateById(Arg.Any<ToDoItem>())).Do(r => throw new Exception());

        // Act
        var result = controller.UpdateById(1, updatedItem);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        repositoryMock.Received(1).UpdateById(Arg.Any<ToDoItem>());
    }
}
