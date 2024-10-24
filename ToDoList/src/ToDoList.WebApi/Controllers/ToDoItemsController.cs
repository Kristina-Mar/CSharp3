namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    public List<ToDoItem> items = [];
    private readonly ToDoItemsContext context;

    public ToDoItemsController(ToDoItemsContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        //try to create an item
        try
        {
            context.ToDoItems.Add(item);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        //return Created();
        /*
        Podla zadania a spravne sa ma vracat CreatedAtAction takto: prvy parameter je cesta, druhy je parameter v tej ceste ReadById (toDoItem), a treti je response body tohto callu.
        Ukazala som to zle ja v breakout room, nedocitala som si cele zadanie, ale zaroven robila som to automaticky podla toho, co mame v praci a tam to mame zle ako pozeram :D
        Aspon je vidiet, ze ani moji seniorni kolegovia, co uz pracuju v IT roky, nevedia vzdy vsetko :)
        */
        return CreatedAtAction(nameof(ReadById), new { toDoItemId = item.ToDoItemId }, ToDoItemGetResponseDto.FromDomain(item)); //201
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItemGetResponseDto>> Read()
    {
        List<ToDoItemGetResponseDto> allItemsDto = [];
        try
        {
            if (context.ToDoItems == null)
            {
                return NotFound();
            }
            /*
            Dobre riesenie, slo by napisat aj cez LINQ napriklad takto:
            itemsDto = items.Select(ToDoItemGetResponseDto.FromDomain).ToList();
            */
            /*foreach (var item in items)
            {
                var itemDto = ToDoItemGetResponseDto.FromDomain(item);
                itemsDto.Add(itemDto);
            }*/
            allItemsDto = context.ToDoItems.Select(ToDoItemGetResponseDto.FromDomain).ToList();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return Ok(allItemsDto);
    }

    [HttpGet("{toDoItemId:int}")]
    public ActionResult<ToDoItemGetResponseDto> ReadById(int toDoItemId)
    {
        // Editor mi podciarkuje Find s chybou: Converting null literal or possible null value to non-nullable type.
        // robim teda z item nullable typ.
        ToDoItem? requestedItem;
        try
        {
            requestedItem = context.ToDoItems.Find(toDoItemId);
            if (requestedItem is null)
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return Ok(ToDoItemGetResponseDto.FromDomain(requestedItem));
    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        var updatedItem = request.ToDomain();

        try
        {
            var itemToUpdateInDb = context.ToDoItems.Find(toDoItemId);
            if (itemToUpdateInDb == null)
            {
                return NotFound();
            }
            itemToUpdateInDb.Name = updatedItem.Name;
            itemToUpdateInDb.Description = updatedItem.Description;
            itemToUpdateInDb.IsCompleted = updatedItem.IsCompleted;
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return NoContent();
    }

    [HttpDelete("{toDoItemId:int}")]
    public ActionResult DeleteById(int toDoItemId)
    {
        // podobne ako pri ReadById
        ToDoItem? itemToDelete;
        try
        {
            itemToDelete = context.ToDoItems.Find(toDoItemId);
            if (itemToDelete is null)
            {
                return NotFound();
            }
            context.ToDoItems.Remove(itemToDelete);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return NoContent();
    }
}
