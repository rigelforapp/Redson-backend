using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("contacts")]
    [Index(nameof(CreatedById), Name = "ix_contacts_created_by_id")]
    [Index(nameof(OrganizationId), Name = "ix_contacts_organization_id")]
    [Index(nameof(UpdatedById), Name = "ix_contacts_updated_by_id")]
    public partial class Contact : Base
    {
        public Contact()
        {
            Orders = new HashSet<Order>();
            Vehicles = new HashSet<Vehicle>();
        }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("first_name")]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(255)]
        public string LastName { get; set; }
        [Column("phone")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("mobile_phone")]
        [StringLength(50)]
        public string MobilePhone { get; set; }
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("job_title")]
        [StringLength(100)]
        public string JobTitle { get; set; }
        [Column("birth_date", TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; }
        [Column("address_2")]
        [StringLength(255)]
        public string Address2 { get; set; }
        [Column("city")]
        [StringLength(255)]
        public string City { get; set; }
        [Column("state")]
        [StringLength(255)]
        public string State { get; set; }
        [Column("postal_code")]
        [StringLength(50)]
        public string PostalCode { get; set; }
        [Column("country")]
        [StringLength(50)]
        public string Country { get; set; }
        [Column("coordinates")]
        [StringLength(255)]
        public string Coordinates { get; set; }
        [Column("website")]
        [StringLength(255)]
        public string Website { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("photo_id")]
        public int? PhotoId { get; set; }
        [Column("group_id")]
        public int? GroupId { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("is_primary_contact")]
        public bool? IsPrimaryContact { get; set; }
        [Column("source")]
        [StringLength(50)]
        public string Source { get; set; }
        [Column("external_id_1")]
        [StringLength(50)]
        public string ExternalId1 { get; set; }
        [Column("external_id_2")]
        [StringLength(50)]
        public string ExternalId2 { get; set; }
        [Column("external_id_3")]
        [StringLength(50)]
        public string ExternalId3 { get; set; }
        [Column("owner_id")]
        public int? OwnerId { get; set; }
        [Column("organization_id")]
        public int? OrganizationId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Contacts")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty("ContactCreatedBies")]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Contacts")]
        public virtual Group Group { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("Contacts")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(PhotoId))]
        [InverseProperty(nameof(File.Contacts))]
        public virtual File Photo { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty("ContactUpdatedBies")]
        public virtual User UpdatedBy { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("ContactUsers")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Order.Contact))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(Vehicle.Contact))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
