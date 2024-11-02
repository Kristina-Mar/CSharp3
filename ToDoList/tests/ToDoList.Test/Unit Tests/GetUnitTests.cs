
namespace ToDoList.Test;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class GetUnitTests
{
    [Fact]
    public void Get_AllItems_ReturnsAllItems()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var toDoItem1Dto = new ToDoItemGetResponseDto
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };
        var toDoItem2Dto = new ToDoItemGetResponseDto
        {
            ToDoItemId = 2,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = true
        };

        List<ToDoItemGetResponseDto> allItemsExpected = [toDoItem1Dto, toDoItem2Dto];

        repositoryMock.Read().Returns(allItemsExpected);

        // Act
        var result = controller.Read();

        // Assert
        var resultResult = Assert.IsType<OkObjectResult>(result.Result);

        var value = resultResult.Value as List<ToDoItemGetResponseDto>;

        Assert.NotNull(value);
        Assert.Equal(allItemsExpected, resultResult.Value);
        Assert.Equal(2, value.Count);
    }

    [Fact]
    public void Get_AllItemsWhenNull_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.Read().ReturnsNull();

        // Act
        var result = controller.Read();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Get_AllItemsUnhandledException_Returns500()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.When(r => r.Read()).Do(r => throw new Exception());

        // Act
        var result = controller.Read();

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
    }

    [Fact]
    public void Get_ValidId_ReturnsItem()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };

        var expectedReturnedItem = new ToDoItemGetResponseDto
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };

        repositoryMock.ReadById(Arg.Any<int>()).Returns(toDoItem);

        // Act
        var result = controller.ReadById(1);

        // Assert
        var resultResult = Assert.IsType<OkObjectResult>(result.Result);
        var value = resultResult.Value as ToDoItemGetResponseDto;
        Assert.NotNull(value);
        Assert.Equal(expectedReturnedItem, value);
    }

    [Fact]
    public void Get_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.ReadById(Arg.Any<int>()).ReturnsNull();

        // Act
        var result = controller.ReadById(2);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Get_ItemByIdUnhandledException_Returns500()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.When(r => r.ReadById(Arg.Any<int>())).Do(r => throw new Exception());

        // Act
        var result = controller.ReadById(1);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
    }
}
