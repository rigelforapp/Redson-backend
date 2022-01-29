using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("products")]
    [Index(nameof(AccountId), Name = "ix_products_account_id")]
    [Index(nameof(CreatedById), Name = "ix_products_created_by_id")]
    [Index(nameof(UpdatedById), Name = "ix_products_updated_by_id")]
    public partial class Product : Base
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            PackageItems = new HashSet<PackageItem>();
        }

        [Column("number")]
        [StringLength(50)]
        public string Number { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("type_id")]
        public int? TypeId { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("is_variation_parent")]
        public bool? IsVariationParent { get; set; }
        [Column("is_purchase_product")]
        public bool? IsPurchaseProduct { get; set; }
        [Column("is_sales_product")]
        public bool? IsSalesProduct { get; set; }
        [Column("unit_price")]
        public decimal? UnitPrice { get; set; }
        [Column("unit_price_tax_excl")]
        public decimal? UnitPriceTaxExcl { get; set; }
        [Column("unit_of_measure")]
        public decimal? UnitOfMeasure { get; set; }
        [Column("is_tax_inclusive")]
        public bool? IsTaxInclusive { get; set; }
        [Column("tax_percent")]
        public decimal? TaxPercent { get; set; }
        [Column("unit_cost")]
        public decimal? UnitCost { get; set; }
        [Column("currency_id")]
        public int? CurrencyId { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("is_stockable")]
        public bool? IsStockable { get; set; }
        [Column("manufacturer_id")]
        public int? ManufacturerId { get; set; }
        [Column("manufacturer_product_number")]
        [StringLength(50)]
        public string ManufacturerProductNumber { get; set; }
        [Column("supplier_id")]
        public int? SupplierId { get; set; }
        [Column("warranty_duration")]
        [StringLength(50)]
        public string WarrantyDuration { get; set; }
        [Column("barcode")]
        [StringLength(50)]
        public string Barcode { get; set; }
        [Column("serial_number")]
        [StringLength(50)]
        public string SerialNumber { get; set; }
        [Column("minimum_quantity")]
        public short? MinimumQuantity { get; set; }
        [Column("quantity")]
        public short? Quantity { get; set; }
        [Column("location_id")]
        public int? LocationId { get; set; }
        [Column("parent_product_id")]
        public int? ParentProductId { get; set; }
        [Column("external_id_1")]
        [StringLength(50)]
        public string ExternalId1 { get; set; }
        [Column("external_id_2")]
        [StringLength(50)]
        public string ExternalId2 { get; set; }
        [Column("external_id_3")]
        [StringLength(50)]
        public string ExternalId3 { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Products")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.ProductCreatedBies))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty("Products")]
        public virtual Manufacturer Manufacturer { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty("Products")]
        public virtual Type Type { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.ProductUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        [InverseProperty(nameof(OrderItem.Product))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [InverseProperty(nameof(PackageItem.Product))]
        public virtual ICollection<PackageItem> PackageItems { get; set; }
    }
}
