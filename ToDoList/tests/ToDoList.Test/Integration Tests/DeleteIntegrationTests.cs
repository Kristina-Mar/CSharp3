namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class DeleteIntegrationTests
{
    [Fact]
    public void Delete_ValiId_DeletesItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItemDtoRequest = new ToDoItemCreateRequestDto("Test name", "Test description", false);
        int expectedNumberOfItemsAfterDeleting = repository.Read().Count();

        controller.Create(toDoItemDtoRequest);
        var newItemId = repository.Read().Max(i => i.ToDoItemId);

        // Act
        var result = controller.DeleteById(newItemId);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.Null(repository.ReadById(newItemId));
        Assert.Equal(expectedNumberOfItemsAfterDeleting, repository.Read().Count());
    }

    [Fact]
    public void Delete_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);
        var invalidId = -1;

        // Act
        var result = controller.DeleteById(invalidId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        Assert.Null(repository.ReadById(invalidId));
    }
}
