using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApplication.ToDoList.Dto
{
    [AutoMap(typeof(ToDo.ToDoList))]
    public class ToDoListDto : EntityDto, IConcurrencyStamp
    {
        [Required]
        public string TaskName { get; set; }

        public string Desciption { get; set; }
        public bool IsCompleted { get; set; }
        public string Category { get; set; }
        public DateTime? CompletedOn { get; set; }
        public long UserId { get; set; }
        public int TenantId { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
