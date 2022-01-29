using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("orders")]
    [Index(nameof(ContactId), Name = "ix_orders_contact_id")]
    [Index(nameof(CreatedById), Name = "ix_orders_created_by_id")]
    [Index(nameof(CurrencyId), Name = "ix_orders_currency_id")]
    [Index(nameof(OrganizationId), Name = "ix_orders_organization_id")]
    [Index(nameof(UpdatedById), Name = "ix_orders_updated_by_id")]
    [Index(nameof(VehicleId), Name = "ix_orders_vehicle_id")]
    public partial class Order : Base
    {
        public Account Account { get; set; }
        public Order ParentOrder { get; set; }

        public Order()
        {
            Comments = new HashSet<Comment>();
            OrderHistories = new HashSet<OrderHistory>();
            OrderItems = new HashSet<OrderItem>();
            Tasks = new HashSet<Task>();
            //Organization = new Organization();
        }

        [Column("number")]
        [StringLength(50)]
        public string Number { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("type_id")]
        public int? TypeId { get; set; }
        [Column("status")]
        [StringLength(100)]
        public string Status { get; set; }
        [Column("date")]
        public DateTime? Date { get; set; }
        [Column("priority")]
        public short? Priority { get; set; }
        [Column("measure_value_1")]
        public int? MeasureValue1 { get; set; }
        [Column("unit_of_measure_1")]
        [StringLength(50)]
        public string UnitOfMeasure1 { get; set; }
        [Column("measure_value_2")]
        public int? MeasureValue2 { get; set; }
        [Column("unit_of_measure_2")]
        [StringLength(50)]
        public string UnitOfMeasure2 { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("start_date")]
        public DateTime? StartDate { get; set; }
        [Column("end_date")]
        public DateTime? EndDate { get; set; }
        [Column("planned_start_date")]
        public DateTime? PlannedStartDate { get; set; }
        [Column("planned_end_date")]
        public DateTime? PlannedEndDate { get; set; }
        [Column("maintenance_plan_id")]
        public int? MaintenancePlanId { get; set; }
        [Column("compliance_status")]
        public short? ComplianceStatus { get; set; }
        [Column("vehicle_id")]
        public int? VehicleId { get; set; }
        [Column("contact_id")]
        public int? ContactId { get; set; }
        [Column("organization_id")]
        public int? OrganizationId { get; set; }
        [Column("location_id")]
        public int? LocationId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }
        [Column("sub_total")]
        public decimal? SubTotal { get; set; }
        [Column("discount")]
        public decimal? Discount { get; set; }
        [Column("tax")]
        public decimal? Tax { get; set; }
        [Column("total")]
        public decimal? Total { get; set; }
        [Column("currency_id")]
        public int? CurrencyId { get; set; }
        [Column("owner_id")]
        public int? OwnerId { get; set; }
        [Column("technician_id")]
        public int? TechnicianId { get; set; }
        [Column("serviced_by_id")]
        public int? ServicedById { get; set; }
        [Column("parent_order_id")]
        public int? ParentOrderId { get; set; }
        [Column("external_reference")]
        [StringLength(50)]
        public string ExternalReference { get; set; }
        [Column("external_id_1")]
        [StringLength(50)]
        public string ExternalId1 { get; set; }
        [Column("external_id_2")]
        [StringLength(50)]
        public string ExternalId2 { get; set; }
        [Column("external_id_3")]
        [StringLength(50)]
        public string ExternalId3 { get; set; }
        [Column("token")]
        [StringLength(255)]
        public string Token { get; set; }

        [ForeignKey(nameof(ContactId))]
        [InverseProperty("Orders")]
        public virtual Contact Contact { get; set; }
        
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.OrderCreatedBies))]
        public virtual User CreatedBy { get; set; }
        
        [ForeignKey(nameof(CurrencyId))]
        [InverseProperty("Orders")]
        public virtual Currency Currency { get; set; }
        
        [ForeignKey(nameof(LocationId))]
        [InverseProperty("Orders")]
        public virtual Location Location { get; set; }
        
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("Orders")]
        public virtual Organization Organization { get; set; }
        
        [ForeignKey(nameof(OwnerId))]
        [InverseProperty(nameof(User.OrderOwners))]
        public virtual User Owner { get; set; }
        
        [ForeignKey(nameof(TechnicianId))]
        [InverseProperty(nameof(User.OrderTechnicians))]
        public virtual User Technician { get; set; }
        
        [ForeignKey(nameof(TypeId))]
        [InverseProperty("Orders")]
        public virtual Type Type { get; set; }
        
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.OrderUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        
        [ForeignKey(nameof(VehicleId))]
        [InverseProperty("Orders")]
        public virtual Vehicle Vehicle { get; set; }
        
        [InverseProperty(nameof(Comment.Order))]
        public virtual ICollection<Comment> Comments { get; set; }
        
        [InverseProperty(nameof(OrderHistory.Order))]
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
        
        [InverseProperty(nameof(OrderItem.Order))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [InverseProperty(nameof(Task.EntityNavigation))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
