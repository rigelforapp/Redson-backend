using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("vehicles_custom_fields")]
    public partial class VehiclesCustomField : Base
    {
        [Column("vehicle_id")]
        public int? VehicleId { get; set; }
        [Column("name")]
        [StringLength(500)]
        public string Name { get; set; }
        [Column("content")]
        [StringLength(500)]
        public string Content { get; set; }

        [ForeignKey(nameof(VehicleId))]
        [InverseProperty("VehiclesCustomFields")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
