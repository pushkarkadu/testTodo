using System.Linq;
using System;

namespace MyApplication.EntityFrameworkCore.Seed.Host
{
    public class ToDoListDefaultDataCreator
    {
        private readonly MyApplicationDbContext _context;

        public ToDoListDefaultDataCreator(MyApplicationDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateToDoLists();
        }

        private void CreateToDoLists()
        {
            // Admin role for host

            var hasAnyToDo = _context.ToDoLists.FirstOrDefault()!= null;
            if (!hasAnyToDo)
            {
                _context.ToDoLists.Add(new ToDo.ToDoList { TaskName ="Utility Bill", Desciption = "Pay Utility Bill", IsCompleted = true, Category = "category 1", UserId = 1});
                _context.ToDoLists.Add(new ToDo.ToDoList { TaskName ="Membership", Desciption = "Clear Membership due", IsCompleted = false, Category = "category 1", UserId = 1});
                _context.ToDoLists.Add(new ToDo.ToDoList { TaskName ="Utility Bill 1", Desciption = "Pay Utility Bill", IsCompleted = false, Category = "category 1", UserId = 1});
                _context.ToDoLists.Add(new ToDo.ToDoList { TaskName ="Utility Bill 2", Desciption = "Pay Utility Bill", IsCompleted = false, Category = "category 1", UserId = 1});
                _context.ToDoLists.Add(new ToDo.ToDoList { TaskName ="Utility Bill 3", Desciption = "Pay Utility Bill", IsCompleted = false, Category = "category 1", UserId = 1});
                _context.ToDoLists.Add(new ToDo.ToDoList { TaskName ="Utility Bill 4", Desciption = "Pay Utility Bill", IsCompleted = false, Category = "category 1", UserId = 1});
                _context.ToDoLists.Add(new ToDo.ToDoList { TaskName ="Utility Bill 5", Desciption = "Pay Utility Bill", IsCompleted = false, Category = "category 1", UserId = 1});
                _context.ToDoLists.Add(new ToDo.ToDoList { TaskName ="Utility Bill 6", Desciption = "Pay Utility Bill", IsCompleted = false, Category = "category 1", UserId = 1});
                _context.SaveChanges();
            }

            // Grant all permissions to admin role for host

           
                _context.SaveChanges();
        }
    }
}
