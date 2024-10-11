namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    private static readonly List<ToDoItem> items = [];

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        //try to create an item
        try
        {
            item.ToDoItemId = items.Count == 0 ? 1 : items.Max(o => o.ToDoItemId) + 1;
            items.Add(item);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        //return Created();
        return CreatedAtAction("Create", item); //201
    }

    [HttpGet]
    public IActionResult Read()
    {
        List<ToDoItemGetResponseDto> itemsDto = [];
        try
        {
            if (items == null)
            {
                return NotFound();
            }
            foreach (var item in items)
            {
                var itemDto = ToDoItemGetResponseDto.FromDomain(item);
                itemsDto.Add(itemDto);
            }
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return Ok(itemsDto);
    }

    [HttpGet("{toDoItemId:int}")]
    public IActionResult ReadById(int toDoItemId)
    {
        ToDoItem item;
        try
        {
            item = items.Find(i => i.ToDoItemId == toDoItemId);
            if (item is null)
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return Ok(ToDoItemGetResponseDto.FromDomain(item));
    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        var updatedItem = request.ToDomain();
        updatedItem.ToDoItemId = toDoItemId;
        try
        {
            int index = items.FindIndex(i => i.ToDoItemId == toDoItemId);
            if (index == -1)
            {
                return NotFound();
            }
            items[index] = updatedItem;
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return NoContent();
    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {
        ToDoItem itemToDelete;
        try
        {
            itemToDelete = items.Find(i => i.ToDoItemId == toDoItemId);
            if (itemToDelete is null)
            {
                return NotFound();
            }
            items.Remove(itemToDelete);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return NoContent();
    }
}
