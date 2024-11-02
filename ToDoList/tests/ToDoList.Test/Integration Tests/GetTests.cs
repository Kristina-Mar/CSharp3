
namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.WebApi.Controllers;

public class GetTests
{
    /* [Fact]
     public void Get_AllItems_ReturnsAllItems()
     {
         // Arrange
         var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
         var controller = new ToDoItemsController(context);
         controller.items = [];
         var toDoItem = new ToDoItem
         {
             ToDoItemId = 1,
             Name = "Test name",
             Description = "Test description",
             IsCompleted = false
         };
         controller.items.Add(toDoItem);

         // Act
         var result = controller.Read();

         // Assert
         //Assert.True(result.Result is OkObjectResult);
         var resultResult = Assert.IsType<OkObjectResult>(result.Result);

         var value = resultResult.Value as IEnumerable<ToDoItemGetResponseDto>;

         Assert.NotNull(value);
         Assert.Single(value);
         Assert.Equal(ToDoItemGetResponseDto.FromDomain(toDoItem), value.ToList()[0]);
     }

     [Fact]
     public void Get_AllItemsWhenNull_ReturnsNotFound()
     {
         // Arrange
         var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
         var controller = new ToDoItemsController(context);
         controller.items = null;

         // Act
         var result = controller.Read();
         var resultResult = result.Result;

         // Assert
         Assert.IsType<NotFoundResult>(resultResult);
     }

     [Fact]
     public void Get_ValidId_ReturnsItem()
     {
         // Arrange
         var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
         var controller = new ToDoItemsController(context);
         controller.items = [];
         var toDoItem = new ToDoItem
         {
             ToDoItemId = 1,
             Name = "Test name",
             Description = "Test description",
             IsCompleted = false
         };
         controller.items.Add(toDoItem);

         // Act
         var result = controller.ReadById(1);

         // Assert
         var resultResult = Assert.IsType<OkObjectResult>(result.Result);
         var value = resultResult.Value as ToDoItemGetResponseDto;
         Assert.NotNull(value);
         Assert.Equal(ToDoItemGetResponseDto.FromDomain(toDoItem), value);
     }

     [Fact]
     public void Get_InvalidId_ReturnsNotFound()
     {
         // Arrange
         var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
         var controller = new ToDoItemsController(context);
         controller.items = [];
         var toDoItem = new ToDoItem
         {
             ToDoItemId = 1,
             Name = "Test name",
             Description = "Test description",
             IsCompleted = false
         };
         controller.items.Add(toDoItem);

         // Act
         var result = controller.ReadById(2);

         // Assert
         Assert.IsType<NotFoundResult>(result.Result);
         Assert.DoesNotContain(controller.items, i => i.ToDoItemId == 2);
     }*/
}
