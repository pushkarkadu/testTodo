using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyApplication.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyApplication.ToDo
{
    [Table("tbltodolists")]
    public class ToDoList : FullAuditedEntity,  IConcurrencyStamp
    {
        public string TaskName { get; set; }
        public string Category { get; set; }
        public string Desciption { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedOn{ get; set; }
        public long UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    }
}
