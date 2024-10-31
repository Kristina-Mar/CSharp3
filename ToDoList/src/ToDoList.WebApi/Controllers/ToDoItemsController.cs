namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    private readonly IRepository<ToDoItem> repository;

    public ToDoItemsController(IRepository<ToDoItem> repository)
    {
        this.repository = repository;
    }

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        //try to create an item
        try
        {
            repository.Create(item);
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
            /*
            Dobre riesenie, slo by napisat aj cez LINQ napriklad takto:
            itemsDto = items.Select(ToDoItemGetResponseDto.FromDomain).ToList();
            */
            /*foreach (var item in items)
            {
                var itemDto = ToDoItemGetResponseDto.FromDomain(item);
                itemsDto.Add(itemDto);
            }*/
            allItemsDto = repository.Read();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return (allItemsDto != null) ? Ok(allItemsDto) : NotFound();
    }

    [HttpGet("{toDoItemId:int}")]
    public ActionResult<ToDoItemGetResponseDto> ReadById(int toDoItemId)
    {
        // Editor mi podciarkuje Find s chybou: Converting null literal or possible null value to non-nullable type.
        // robim teda z item nullable typ.
        ToDoItem? requestedItem;
        try
        {
            requestedItem = repository.ReadById(toDoItemId);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return (requestedItem != null) ? Ok(ToDoItemGetResponseDto.FromDomain(requestedItem)) : NotFound();
    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        var updatedItem = request.ToDomain();
        bool isUpdated;

        try
        {
            isUpdated = repository.UpdateById(toDoItemId, updatedItem);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return isUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{toDoItemId:int}")]
    public ActionResult DeleteById(int toDoItemId)
    {
        ToDoItem? itemToDelete;
        bool isDeleted;

        try
        {
            isDeleted = repository.DeleteById(toDoItemId);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return isDeleted ? NoContent() : NotFound();
    }
}
