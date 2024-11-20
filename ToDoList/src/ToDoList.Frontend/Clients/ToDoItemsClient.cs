using ToDoList.Domain.DTOs;
using ToDoList.Frontend.Views;
using ToDoList.Frontend.Clients;

public class ToDoItemsClient(HttpClient httpClient) : IToDoItemsClient
{
    public async Task<List<ToDoItemView>> ReadItemsAsync()
    {
        var ToDoItemsView = new List<ToDoItemView>();
        var response = await httpClient.GetFromJsonAsync<List<ToDoItemGetResponseDto>>("api/ToDoItems");

        ToDoItemsView = response.Select(dto => new ToDoItemView
        {
            ToDoItemId = dto.ToDoItemId,
            Name = dto.Name,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted
        }).ToList();

        return ToDoItemsView;
    }
}
