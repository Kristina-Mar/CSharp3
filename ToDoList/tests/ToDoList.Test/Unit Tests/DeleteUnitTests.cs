namespace ToDoList.Test;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using FluentAssertions;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class DeleteUnitTests
{
    [Fact]
    public void Delete_DeleteByIdValidItemId_ReturnsNoContent()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.DeleteById(Arg.Any<int>()).Returns(true);

        // Act
        var result = controller.DeleteById(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
        repositoryMock.Received(1).DeleteById(Arg.Any<int>());

        result.Should().BeOfType<NoContentResult>(); // FluentAssertions alternative
    }

    [Fact]
    public void Delete_DeleteByIdInvalidItemId_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.DeleteById(Arg.Any<int>()).Returns(false);

        // Act
        var result = controller.DeleteById(-1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        repositoryMock.Received(1).DeleteById(Arg.Any<int>());

        result.Should().BeOfType<NotFoundResult>(); // FluentAssertions alternative
    }

    [Fact]
    public void Delete_DeleteByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.When(r => r.DeleteById(Arg.Any<int>())).Throws(new Exception());

        // Act
        var result = controller.DeleteById(1);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        repositoryMock.Received(1).DeleteById(Arg.Any<int>());

        result.Should().BeOfType<ObjectResult>().Which.StatusCode.Should().Be(500); // FluentAssertions alternative
    }
}
