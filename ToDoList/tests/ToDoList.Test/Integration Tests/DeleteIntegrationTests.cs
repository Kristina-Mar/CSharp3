namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class DeleteIntegrationTests
{
    [Fact]
    public void Delete_DeleteByIdValidItemId_ReturnsNoContentAndDeletesItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItem = new ToDoItem()
        {
            Name = "Delete test name",
            Description = "Delete test description",
            IsCompleted = false
        };
        int expectedNumberOfItemsAfterDeleting = repository.Read().Count();

        context.Add(toDoItem);
        context.SaveChanges();

        // Act
        var result = controller.DeleteById(toDoItem.ToDoItemId);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.Null(repository.ReadById(toDoItem.ToDoItemId));
        Assert.Equal(expectedNumberOfItemsAfterDeleting, repository.Read().Count());
    }

    [Fact]
    public void Delete_DeleteByIdInvalidItemId_ReturnsNotFound()
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
