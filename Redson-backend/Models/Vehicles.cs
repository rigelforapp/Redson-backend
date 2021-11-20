using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("vehicles")]
    [Index(nameof(ContactId), Name = "ix_vehicles_contact_id")]
    [Index(nameof(CreatedById), Name = "ix_vehicles_created_by_id")]
    [Index(nameof(OrganizationId), Name = "ix_vehicles_organization_id")]
    [Index(nameof(UpdatedById), Name = "ix_vehicles_updated_by_id")]
    public partial class Vehicle : Base
    {
        public Vehicle()
        {
            OrderItems = new HashSet<OrderItem>();
            Orders = new HashSet<Order>();
            VehiclesCustomFields = new HashSet<VehiclesCustomField>();
        }

        [Column("number")]
        [StringLength(50)]
        public string Number { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("registration_number")]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }
        [Column("type_id")]
        public int? TypeId { get; set; }
        [Column("manufacturer_model_id")]
        public int? ManufacturerModelId { get; set; }
        [Column("version")]
        [StringLength(50)]
        public string Version { get; set; }
        [Column("manufactured_year")]
        public short? ManufacturedYear { get; set; }
        [Column("group_id")]
        public int? GroupId { get; set; }
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; }
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
        [Column("external_id_1")]
        [StringLength(50)]
        public string ExternalId1 { get; set; }
        [Column("external_id_2")]
        [StringLength(50)]
        public string ExternalId2 { get; set; }
        [Column("external_id_3")]
        [StringLength(50)]
        public string ExternalId3 { get; set; }
        [Column("photo_id")]
        public int? PhotoId { get; set; }
        [Column("serial_number")]
        [StringLength(50)]
        public string SerialNumber { get; set; }
        [Column("fuel_type")]
        [StringLength(50)]
        public string FuelType { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("parent_vehicle_id")]
        public int? ParentVehicleId { get; set; }
        [Column("owner_id")]
        public int? OwnerId { get; set; }
        [Column("last_service")]
        public DateTime? LastService { get; set; }
        [Column("next_service")]
        public DateTime? NextService { get; set; }
        [Column("contact_id")]
        public int? ContactId { get; set; }
        [Column("organization_id")]
        public int? OrganizationId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        [ForeignKey(nameof(ContactId))]
        [InverseProperty("Vehicles")]
        public virtual Contact Contact { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.VehicleCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Vehicles")]
        public virtual Group Group { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("Vehicles")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty("Vehicles")]
        public virtual Type Type { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.VehicleUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        [InverseProperty(nameof(OrderItem.Vehicle))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [InverseProperty(nameof(Order.Vehicle))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(VehiclesCustomField.Vehicle))]
        public virtual ICollection<VehiclesCustomField> VehiclesCustomFields { get; set; }
    }
}
