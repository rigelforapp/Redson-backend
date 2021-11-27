using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("groups")]
    [Index(nameof(CreatedById), Name = "ix_groups_created_by_id")]
    [Index(nameof(OrganizationId), Name = "ix_groups_organization_id")]
    [Index(nameof(UpdatedById), Name = "ix_groups_updated_by_id")]
    public partial class Group : Base
    {
        public Group()
        {
            /*Contacts = new HashSet<Contact>();
            Vehicles = new HashSet<Vehicle>();*/
        }

        /*[Key]
        [Column("id")]
        public int? Id { get; set; } = null;*/
        [Column("organization_id")]
        public int? OrganizationId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("type_id")]
        public int? TypeId { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("parent_group_id")]
        public int? ParentGroupId { get; set; }

        /*[ForeignKey(nameof(CreatedById))]
        //[InverseProperty(nameof(User.GroupCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("Groups")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty("Groups")]
        public virtual Type Type { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        //[InverseProperty(nameof(User.GroupUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        [InverseProperty(nameof(Contact.Group))]
        public virtual ICollection<Contact> Contacts { get; set; }
        [InverseProperty(nameof(Vehicle.Group))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }*/
    }
}
