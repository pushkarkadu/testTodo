using Abp.Application.Services;
using MyApplication.ToDoList.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.ToDoList
{
    public interface IToDoListAppService : IApplicationService
    {
        Task<ToDoListDto> InsertOrUpdateAsync(ToDoListDto entityDto);
        Task DeleteToDo(ToDoListDto entityDto);
        Task<List<ToDoListDto>> FetchAllToDos(long userId);
    }
}
