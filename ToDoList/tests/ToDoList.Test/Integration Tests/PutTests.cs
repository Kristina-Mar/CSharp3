namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.WebApi.Controllers;

public class PutTests
{
    /* [Fact]
     public void Put_ValidId_UpdatesItem()
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

         var updatedItem = new ToDoItemUpdateRequestDto("Updated name", "Updated description", true);

         // Act
         var result = controller.UpdateById(1, updatedItem);
         var updatedItemInList = controller.items.Find(i => i.ToDoItemId == 1);

         // Assert
         Assert.IsType<NoContentResult>(result);
         Assert.Equal(1, updatedItemInList.ToDoItemId);
         Assert.Equal(updatedItem.Name, updatedItemInList.Name);
         Assert.Equal(updatedItem.Description, updatedItemInList.Description);
         Assert.Equal(updatedItem.IsCompleted, updatedItemInList.IsCompleted);
     }

     [Fact]
     public void Put_InvalidId_ReturnsNotFound()
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

         var updatedItem = new ToDoItemUpdateRequestDto("Updated name", "Updated description", true);

         // Act
         var result = controller.UpdateById(2, updatedItem);

         // Assert
         Assert.IsType<NotFoundResult>(result);
         Assert.DoesNotContain(controller.items, i => i.ToDoItemId == 2);
         Assert.DoesNotContain(controller.items, i => i.Name == updatedItem.Name);
     }*/
}
