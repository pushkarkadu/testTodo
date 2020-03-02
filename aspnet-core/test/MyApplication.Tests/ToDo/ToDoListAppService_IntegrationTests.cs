using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using MyApplication.Users.Dto;
using MyApplication.ToDoList;
using MyApplication.ToDoList.Dto;
using System;
using System.Linq;

namespace MyApplication.Tests.ToDo
{
    public class ToDoListAppService_IntegrationTests : MyApplicationTestBase
    {
        private readonly IToDoListAppService _todoAppService;

        public ToDoListAppService_IntegrationTests()
        {
            _todoAppService = Resolve<IToDoListAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await _todoAppService.FetchAllToDos(1);

            // Assert
            output.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task InsertOrUpdateAsync_WhenPassedNewObject_InsertsRecord_Test()
        {
            var taskName = Guid.NewGuid().ToString();
            // Act
            await _todoAppService.InsertOrUpdateAsync(
                new ToDoListDto
                {
                    TaskName = taskName,
                    Desciption = taskName,
                    Category = taskName,
                    IsCompleted = false,
                });

            //assert
            await UsingDbContextAsync(async context =>
            {
                var createdTask = await context.ToDoLists.FirstOrDefaultAsync(u => u.TaskName == taskName);
                createdTask.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task InsertOrUpdateAsync_WhenPassedExistingObject_InsertsRecord_Test()
        {
            var taskName = Guid.NewGuid().ToString();
            var updatedTaskName = Guid.NewGuid().ToString();
            // Act
            var createdRecord = await _todoAppService.InsertOrUpdateAsync(
                 new ToDoListDto
                 {
                     TaskName = taskName,
                     Desciption = taskName,
                     Category = taskName,
                     IsCompleted = false,
                 });

            await UsingDbContextAsync(async context =>
            {
                var createdTask = await context.ToDoLists.FirstOrDefaultAsync(u => u.Id == createdRecord.Id);
                createdTask.TaskName.ShouldBe(taskName);
                createdRecord.ConcurrencyStamp = createdTask.ConcurrencyStamp;
            });

            createdRecord.TaskName = updatedTaskName;
            await _todoAppService.InsertOrUpdateAsync(createdRecord);

            //assert
            await UsingDbContextAsync(async context =>
            {
                var createdTask = await context.ToDoLists.FirstOrDefaultAsync(u => u.Id == createdRecord.Id);
                createdTask.TaskName.ShouldBe(updatedTaskName);
            });
        }

        [Fact]
        public async Task DeleteToDo_DeletsRecord_Test()
        {
            //setup
            var taskName = Guid.NewGuid().ToString();
            var updatedTaskName = Guid.NewGuid().ToString();
            // Act
            await _todoAppService.InsertOrUpdateAsync(
                 new ToDoListDto
                 {
                     TaskName = taskName,
                     Desciption = taskName,
                     Category = taskName,
                     IsCompleted = false,
                     UserId = 1
                 });

            await UsingDbContextAsync(async context =>
            {
                var createdTask = await context.ToDoLists.FirstOrDefaultAsync(u => u.TaskName == taskName);
                createdTask.TaskName.ShouldBe(taskName);
            });
            var createdRecord = (await _todoAppService.FetchAllToDos(1)).FirstOrDefault(x => x.TaskName == taskName);
            await _todoAppService.DeleteToDo(createdRecord);
            createdRecord = (await _todoAppService.FetchAllToDos(1)).FirstOrDefault(x => x.TaskName == taskName);
            createdRecord.ShouldBeNull();

            //assert
        }
    }
}