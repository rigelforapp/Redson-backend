using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("currencies")]
    [Index(nameof(CountryId), Name = "ix_currencies_country_id")]
    [Index(nameof(CreatedById), Name = "ix_currencies_created_by_id")]
    [Index(nameof(UpdatedById), Name = "ix_currencies_updated_by_id")]
    public partial class Currency : Base
    {
        public Currency()
        {
            Accounts = new HashSet<Account>();
            Orders = new HashSet<Order>();
        }

        [Column("delete")]
        public bool? Delete { get; set; }
        [Column("code")]
        [StringLength(255)]
        public string Code { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("badge")]
        [StringLength(255)]
        public string Badge { get; set; }
        [Column("symbol")]
        [StringLength(255)]
        public string Symbol { get; set; }
        [Column("state")]
        [StringLength(1)]
        public string State { get; set; }
        [Column("logo")]
        [StringLength(255)]
        public string Logo { get; set; }
        [Column("country_id")]
        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Currencies")]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.CurrencyCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.CurrencyUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        [InverseProperty(nameof(Account.Currency))]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty(nameof(Order.Currency))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
