using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("tasks")]
    public partial class Task : Base
    {
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("type_id")]
        public int? TypeId { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("due_date")]
        public DateTime? DueDate { get; set; }
        [Column("due_value")]
        public int? DueValue { get; set; }
        [Column("reminder_date")]
        public DateTime? ReminderDate { get; set; }
        [Column("reminder_value")]
        public int? ReminderValue { get; set; }
        [Column("assigned_to_id")]
        public int? AssignedToId { get; set; }
        [Column("is_completed")]
        public bool? IsCompleted { get; set; }
        [Column("completed_at")]
        public DateTime? CompletedAt { get; set; }
        [Column("position")]
        public short? Position { get; set; }
        [Column("parent_task_id")]
        public int? ParentTaskId { get; set; }
        [Column("external_id_1")]
        [StringLength(255)]
        public string ExternalId1 { get; set; }
        [Column("external_id_2")]
        [StringLength(255)]
        public string ExternalId2 { get; set; }
        [Column("external_id_3")]
        [StringLength(255)]
        public string ExternalId3 { get; set; }
        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("parent_type")]
        [StringLength(20)]
        public string ParentType { get; set; }
        [Column("entity")]
        [StringLength(20)]
        public string Entity { get; set; }
        [Column("entity_id")]
        public int? EntityId { get; set; }

        [ForeignKey(nameof(AssignedToId))]
        [InverseProperty(nameof(User.Tasks))]
        public virtual User AssignedTo { get; set; }
        [ForeignKey(nameof(EntityId))]
        [InverseProperty(nameof(OrderItem.Tasks))]
        public virtual OrderItem Entity1 { get; set; }
        [ForeignKey(nameof(EntityId))]
        [InverseProperty(nameof(Order.Tasks))]
        public virtual Order EntityNavigation { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty("Tasks")]
        public virtual Type Type { get; set; }
    }
}
