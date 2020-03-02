using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.ToDo
{
    public class ToDoListManager : DomainService, IToDoListManager
    {
        private readonly IRepository<ToDoList, int> _todoListRepository;
        public ToDoListManager(IRepository<ToDoList, int> todoListRepository)
        {
            _todoListRepository = todoListRepository;

        }
        public async Task DeleteAsync(int id)
            => await _todoListRepository.DeleteAsync(id).ConfigureAwait(false);

        public IQueryable<ToDoList> GetAll()
            => _todoListRepository.GetAll();

        public async Task<ToDoList> GetSiteByIdAsync(int id)
            => await _todoListRepository.FirstOrDefaultAsync(id).ConfigureAwait(false);

        public async Task<ToDoList> InsertOrUpdateAsync(ToDoList entity)
            => await _todoListRepository.InsertOrUpdateAsync(entity).ConfigureAwait(false);
    }
}
