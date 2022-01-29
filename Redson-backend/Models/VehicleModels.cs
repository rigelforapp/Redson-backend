using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("vehicle_models")]
    public partial class VehicleModel : Base
    {
        public VehicleModel()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Column("account_id")]
        public int? AccountId { get; set; }

        [Column("manufacturer_id")]
        public int? ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty("VehicleModels")]
        public virtual Manufacturer Manufacturer { get; set; }

        [InverseProperty(nameof(Vehicle.VehicleModel))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
