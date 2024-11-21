namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController(IRepositoryAsync<ToDoItem> repositoryAsync) : ControllerBase
{
    private readonly IRepositoryAsync<ToDoItem> repositoryAsync = repositoryAsync;

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ToDoItemCreateRequestDto request)
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        //try to create an item
        try
        {
            await repositoryAsync.CreateAsync(item);
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
        return CreatedAtAction(nameof(ReadByIdAsync), new { toDoItemId = item.ToDoItemId }, ToDoItemGetResponseDto.FromDomain(item)); //201
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItemGetResponseDto>>> ReadAsync()
    {
        IEnumerable<ToDoItem> allItems = [];
        try
        {
            allItems = await repositoryAsync.ReadAsync();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        return (allItems != null) ? Ok(allItems.Select(ToDoItemGetResponseDto.FromDomain).ToList()) : NotFound();
    }

    [HttpGet("{toDoItemId:int}")]
    public async Task<ActionResult<ToDoItemGetResponseDto>> ReadByIdAsync(int toDoItemId)
    {
        // Editor mi podciarkuje Find s chybou: Converting null literal or possible null value to non-nullable type.
        // robim teda z item nullable typ.
        ToDoItem? requestedItem;
        try
        {
            requestedItem = await repositoryAsync.ReadByIdAsync(toDoItemId);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        return (requestedItem != null) ? Ok(ToDoItemGetResponseDto.FromDomain(requestedItem)) : NotFound();
    }

    [HttpPut("{toDoItemId:int}")]
    public async Task<IActionResult> UpdateByIdAsync(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        var updatedItem = request.ToDomain();
        updatedItem.ToDoItemId = toDoItemId;
        bool isUpdated;

        try
        {
            isUpdated = await repositoryAsync.UpdateByIdAsync(updatedItem);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        return isUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{toDoItemId:int}")]
    public async Task<ActionResult> DeleteByIdAsync(int toDoItemId)
    {
        bool isDeleted;

        try
        {
            isDeleted = await repositoryAsync.DeleteByIdAsync(toDoItemId);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        return isDeleted ? NoContent() : NotFound();
    }
}
