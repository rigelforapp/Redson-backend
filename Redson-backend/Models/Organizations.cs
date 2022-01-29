using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("organizations")]
    [Index(nameof(AccountId), Name = "ix_organizations_account_id")]
    [Index(nameof(CreatedById), Name = "ix_organizations_created_by_id")]
    [Index(nameof(UpdatedById), Name = "ix_organizations_updated_by_id")]
    public partial class Organization : Base
    {
        public Organization()
        {
            Contacts = new HashSet<Contact>();
            Groups = new HashSet<Group>();
            OrderItems = new HashSet<OrderItem>();
            Orders = new HashSet<Order>();
            Vehicles = new HashSet<Vehicle>();
        }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; }
        [Column("industry")]
        [StringLength(50)]
        public string Industry { get; set; }
        [Column("phone")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("mobile_phone")]
        [StringLength(50)]
        public string MobilePhone { get; set; }
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("billing_name")]
        [StringLength(255)]
        public string BillingName { get; set; }
        [Column("billing_tax_number")]
        [StringLength(50)]
        public string BillingTaxNumber { get; set; }
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
        [Column("product_discount")]
        public decimal? ProductDiscount { get; set; }
        [Column("service_discount")]
        public decimal? ServiceDiscount { get; set; }
        [Column("owner_id")]
        public int? OwnerId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        


        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Organizations")]
        public virtual Account Account { get; set; }
        
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Organizations")]
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(PhotoId))]
        [InverseProperty(nameof(File.Organizations))]
        public virtual File Photo { get; set; }

        [ForeignKey(nameof(OwnerId))]
        [InverseProperty(nameof(User.Organizations))]
        public virtual User Owner { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.OrganizationCreatedBies))]
        public virtual User CreatedBy { get; set; }
        
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.OrganizationUpdatedBies))]
        public virtual User UpdatedBy { get; set; }

        [InverseProperty(nameof(Contact.Organization))]
        public virtual ICollection<Contact> Contacts { get; set; }
        
        [InverseProperty(nameof(Group.Organization))]
        public virtual ICollection<Group> Groups { get; set; }
        
        [InverseProperty(nameof(OrderItem.ServicedBy))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        
        [InverseProperty(nameof(Order.Organization))]
        public virtual ICollection<Order> Orders { get; set; }
        
        [InverseProperty(nameof(Vehicle.Organization))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
