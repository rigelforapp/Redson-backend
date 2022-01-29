using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("countries")]
    [Index(nameof(CreatedById), Name = "ix_countries_created_by_id")]
    [Index(nameof(UpdatedById), Name = "ix_countries_updated_by_id")]
    public partial class Country : Base
    {
        public Country()
        {
            Currencies = new HashSet<Currency>();
        }

        /*[Key]
        [Column("id")]
        public int? Id { get; set; } = null;*/
        [Column("code")]
        [StringLength(255)]
        public string Code { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.CountryCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.CountryUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        [InverseProperty(nameof(Currency.Country))]
        public virtual ICollection<Currency> Currencies { get; set; }
    }
}
