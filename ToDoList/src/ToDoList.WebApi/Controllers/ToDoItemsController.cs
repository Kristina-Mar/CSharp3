namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    public List<ToDoItem> items = [];

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
        List<ToDoItemGetResponseDto> itemsDto = [];
        try
        {
            if (items == null)
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
            itemsDto = items.Select(ToDoItemGetResponseDto.FromDomain).ToList();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return Ok(itemsDto);
    }

    [HttpGet("{toDoItemId:int}")]
    public ActionResult<ToDoItemGetResponseDto> ReadById(int toDoItemId)
    {
        // Editor mi podciarkuje Find s chybou: Converting null literal or possible null value to non-nullable type.
        // robim teda z item nullable typ.
        ToDoItem? item;
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
            // editor nasepkava, aby som pouzila radsej var
            var index = items.FindIndex(i => i.ToDoItemId == toDoItemId);
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
    public ActionResult DeleteById(int toDoItemId)
    {
        // podobne ako pri ReadById
        ToDoItem? itemToDelete;
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
