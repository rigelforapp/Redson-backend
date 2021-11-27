using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("manufacturers")]
    public partial class Manufacturer : Base
    {
        public Manufacturer()
        {
            /*Products = new HashSet<Product>();
            VehicleModels = new HashSet<VehicleModel>();*/
        }

        [Key]
        [Column("id")]
        public int? Id { get; set; } = null;
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("logo_id")]
        public int? LogoId { get; set; }
        [Column("is_vehicle_manufacturer")]
        public bool? IsVehicleManufacturer { get; set; }
        [Column("type_id")]
        public int? TypeId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        /*[ForeignKey(nameof(TypeId))]
        [InverseProperty("Manufacturers")]
        public virtual Type Type { get; set; }
        [InverseProperty(nameof(Product.Manufacturer))]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty(nameof(VehicleModel.Manufacturer))]
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }*/
    }
}
