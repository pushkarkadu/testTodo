using Abp.Authorization;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApplication.ToDo;
using MyApplication.ToDoList.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.ToDoList
{
    public class ToDoListAppService : MyApplicationAppServiceBase, IToDoListAppService
    {
        private readonly IToDoListManager _todoListToDoListManager;
        public ToDoListAppService(IToDoListManager todoListToDoListManager)
        {
            _todoListToDoListManager = todoListToDoListManager;

        }
        [HttpPost]
        public async Task DeleteToDo(ToDoListDto entityDto)
        {
            var existingEntity = await _todoListToDoListManager.GetSiteByIdAsync(entityDto.Id).ConfigureAwait(false);
            CheckForConcurrency(entityDto, existingEntity);// This should be added in custom dto to entity mapper in actual world
            await _todoListToDoListManager.DeleteAsync(entityDto.Id).ConfigureAwait(false);
        }
        
        public async Task<List<ToDoListDto>> FetchAllToDos(long userId)
        {
            var todoList = await _todoListToDoListManager.GetAll()
                                                   .Where(x => x.UserId == userId)
                                                   .AsNoTracking()
                                                   .ToListAsync()
                                                   .ConfigureAwait(false);

            return ObjectMapper.Map<List<ToDoListDto>>(todoList);
        }

        public async Task<ToDoListDto> InsertOrUpdateAsync(ToDoListDto entityDto)
        {
            var existingEntity = new ToDo.ToDoList();
            if (entityDto.Id > 0)
            {
                existingEntity = await _todoListToDoListManager.GetSiteByIdAsync(entityDto.Id).ConfigureAwait(false);
                CheckForConcurrency(entityDto, existingEntity);// This should be added in custom dto to entity mapper in actual world 
                existingEntity = ObjectMapper.Map(entityDto, existingEntity);
            }
            else
            {
                existingEntity = ObjectMapper.Map<ToDo.ToDoList>(entityDto);
            }
            var updatedEntity = await _todoListToDoListManager.InsertOrUpdateAsync(existingEntity).ConfigureAwait(false);

            return ObjectMapper.Map<ToDoListDto>(updatedEntity);
        }

        private void CheckForConcurrency(IConcurrencyStamp entityDto, IConcurrencyStamp entity)
        {
            if (entity.ConcurrencyStamp?.Equals(entityDto.ConcurrencyStamp) == true)
            {
                return;
            }

            throw new UserFriendlyException("Data has been modified. Please refresh.");
        }
    }
}
