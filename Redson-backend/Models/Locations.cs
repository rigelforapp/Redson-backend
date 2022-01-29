using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("locations")]
    [Index(nameof(AccountId), Name = "ix_locations_account_id")]
    [Index(nameof(CreatedById), Name = "ix_locations_created_by_id")]
    [Index(nameof(UpdatedById), Name = "ix_locations_updated_by_id")]
    public partial class Location : Base
    {
        public Location()
        {
            InverseParentLocation = new HashSet<Location>();
            Orders = new HashSet<Order>();
        }

        /*[Key]
        [Column("id")]
        public int? Id { get; set; } = null;*/
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("is_inventory_location")]
        [StringLength(255)]
        public string IsInventoryLocation { get; set; }
        [Column("parent_location_id")]
        public int? ParentLocationId { get; set; }
        [Column("owner_id")]
        public int? OwnerId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Locations")]
        public virtual Account Account { get; set; }
        
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.LocationCreatedBies))]
        public virtual User CreatedBy { get; set; }
        
        [ForeignKey(nameof(ParentLocationId))]
        [InverseProperty(nameof(Location.InverseParentLocation))]
        public virtual Location ParentLocation { get; set; }
       
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.LocationUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
       
        [InverseProperty(nameof(Location.ParentLocation))]
        public virtual ICollection<Location> InverseParentLocation { get; set; }
        
        [InverseProperty(nameof(Order.Location))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
