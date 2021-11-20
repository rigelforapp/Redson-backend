using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("accounts")]
    [Index(nameof(CreatedById), Name = "ix_accounts_created_by_id")]
    [Index(nameof(CurrencyId), Name = "ix_accounts_currency_id")]
    [Index(nameof(UpdatedById), Name = "ix_accounts_updated_by_id")]
    public partial class Account : Base
    {
        public Account()
        {
            Contacts = new HashSet<Contact>();
            Locations = new HashSet<Location>();
            Organizations = new HashSet<Organization>();
            Packages = new HashSet<Package>();
            Products = new HashSet<Product>();
            UsersXRoles = new HashSet<UsersXRole>();
        }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("type_id")]
        public int? TypeId { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
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
        [Column("website")]
        [StringLength(255)]
        public string Website { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("photo_id")]
        public int? PhotoId { get; set; }
        [Column("time_zone")]
        [StringLength(255)]
        public string TimeZone { get; set; }
        [Column("tax_percent")]
        public decimal? TaxPercent { get; set; }
        [Column("currency_id")]
        public int? CurrencyId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Accounts")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.AccountCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(CurrencyId))]
        [InverseProperty("Accounts")]
        public virtual Currency Currency { get; set; }
        [ForeignKey(nameof(PhotoId))]
        [InverseProperty(nameof(File.Accounts))]
        public virtual File Photo { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty("Accounts")]
        public virtual Type Type { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.AccountUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        [InverseProperty(nameof(Contact.Account))]
        public virtual ICollection<Contact> Contacts { get; set; }
        [InverseProperty(nameof(Location.Account))]
        public virtual ICollection<Location> Locations { get; set; }
        [InverseProperty(nameof(Organization.Account))]
        public virtual ICollection<Organization> Organizations { get; set; }
        [InverseProperty(nameof(Package.Account))]
        public virtual ICollection<Package> Packages { get; set; }
        [InverseProperty(nameof(Product.Account))]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty(nameof(UsersXRole.Account))]
        public virtual ICollection<UsersXRole> UsersXRoles { get; set; }
    }
}
