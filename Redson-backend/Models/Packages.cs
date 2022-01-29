using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("packages")]
    [Index(nameof(AccountId), Name = "ix_packages_account_id")]
    [Index(nameof(CreatedById), Name = "ix_packages_created_by_id")]
    [Index(nameof(UpdatedById), Name = "ix_packages_updated_by_id")]
    public partial class Package : Base
    {
        public Package()
        {
            PackageItems = new HashSet<PackageItem>();
        }

        [Column("number")]
        [StringLength(255)]
        public string Number { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Packages")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.PackageCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.PackageUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        [InverseProperty(nameof(PackageItem.Package))]
        public virtual ICollection<PackageItem> PackageItems { get; set; }
    }
}
