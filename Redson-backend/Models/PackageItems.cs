using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("package_items")]
    [Index(nameof(CreatedById), Name = "ix_package_items_created_by_id")]
    [Index(nameof(PackageId), Name = "ix_package_items_package_id")]
    [Index(nameof(ProductId), Name = "ix_package_items_product_id")]
    [Index(nameof(UpdatedById), Name = "ix_package_items_updated_by_id")]
    public partial class PackageItem : Base
    {
        [Column("package_id")]
        public int? PackageId { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("product_id")]
        public int? ProductId { get; set; }
        [Column("quantity")]
        public decimal? Quantity { get; set; }
        [Column("unit_price")]
        public decimal? UnitPrice { get; set; }
        [Column("sub_total")]
        public decimal? SubTotal { get; set; }
        [Column("discount")]
        public decimal? Discount { get; set; }
        [Column("tax_percent")]
        public decimal? TaxPercent { get; set; }
        [Column("tax_amount")]
        public decimal? TaxAmount { get; set; }
        [Column("total")]
        public decimal? Total { get; set; }
        [Column("parent_item_id")]
        public int? ParentItemId { get; set; }
        [Column("position")]
        public short? Position { get; set; }
        [Column("is_separator")]
        public bool? IsSeparator { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.PackageItemCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(PackageId))]
        [InverseProperty("PackageItems")]
        public virtual Package Package { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("PackageItems")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.PackageItemUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
    }
}
