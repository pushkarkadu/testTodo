using Abp.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.ToDo
{
    public interface IToDoListManager : IDomainService
    {
        Task<ToDoList> GetSiteByIdAsync(int id);
        Task<ToDoList> InsertOrUpdateAsync(ToDoList entity);
        Task DeleteAsync(int id);
        IQueryable<ToDoList> GetAll();
    }
}
