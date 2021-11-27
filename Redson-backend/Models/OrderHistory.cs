using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("order_history")]
    public partial class OrderHistory : Base
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; } = null;
        [Column("order_id")]
        public int? OrderId { get; set; }
        [Column("field")]
        [StringLength(50)]
        public string Field { get; set; }
        [Column("new_value")]
        [StringLength(50)]
        public string NewValue { get; set; }
        [Column("old_value")]
        [StringLength(50)]
        public string OldValue { get; set; }
        [Column("start_date")]
        public DateTime? StartDate { get; set; }
        [Column("end_date")]
        public DateTime? EndDate { get; set; }
        [Column("elapsed_time")]
        public int? ElapsedTime { get; set; }

        /*[ForeignKey(nameof(CreatedById))]
        //[InverseProperty(nameof(User.OrderHistoryCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderHistories")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        //[InverseProperty(nameof(User.OrderHistoryUpdatedBies))]
        public virtual User UpdatedBy { get; set; }*/
    }
}
