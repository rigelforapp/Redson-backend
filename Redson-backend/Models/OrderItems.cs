using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("order_items")]
    [Index(nameof(CreatedById), Name = "ix_order_items_created_by_id")]
    [Index(nameof(OrderId), Name = "ix_order_items_order_id")]
    [Index(nameof(ProductId), Name = "ix_order_items_product_id")]
    [Index(nameof(UpdatedById), Name = "ix_order_items_updated_by_id")]
    public partial class OrderItem : Base
    {
        public OrderItem()
        {
            Tasks = new HashSet<Task>();
        }

        [Column("order_id")]
        public int? OrderId { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("product_id")]
        public int? ProductId { get; set; }
        [Column("is_completed")]
        public bool? IsCompleted { get; set; }
        [Column("status")]
        [StringLength(100)]
        public string Status { get; set; }
        [Column("result")]
        public short? Result { get; set; }
        [Column("quantity")]
        public decimal? Quantity { get; set; }
        [Column("unit_price")]
        public decimal? UnitPrice { get; set; }
        [Column("sub_total")]
        public decimal? SubTotal { get; set; }
        [Column("discount")]
        public decimal? Discount { get; set; }
        [Column("tax_percent")]
        public decimal? TaxPercent { get; set; }
        [Column("tax_amount")]
        public decimal? TaxAmount { get; set; }
        [Column("total")]
        public decimal? Total { get; set; }
        [Column("parent_order_item_id")]
        public int? ParentOrderItemId { get; set; }
        [Column("position")]
        public short? Position { get; set; }
        [Column("is_divider")]
        public bool? IsDivider { get; set; }
        [Column("vehicle_id")]
        public int? VehicleId { get; set; }
        [Column("technician_id")]
        public int? TechnicianId { get; set; }
        [Column("serviced_by_id")]
        public int? ServicedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.OrderItemCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderItems")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderItems")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(ServicedById))]
        [InverseProperty(nameof(Organization.OrderItems))]
        public virtual Organization ServicedBy { get; set; }
        [ForeignKey(nameof(TechnicianId))]
        [InverseProperty(nameof(User.OrderItemTechnicians))]
        public virtual User Technician { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.OrderItemUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        [ForeignKey(nameof(VehicleId))]
        [InverseProperty("OrderItems")]
        public virtual Vehicle Vehicle { get; set; }
        [InverseProperty(nameof(Task.Entity1))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
