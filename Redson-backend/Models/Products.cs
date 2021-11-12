using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Products : Base
    {
        public string number { get; set; } = null;
        public string name { get; set; } = null;
        public string description { get; set; } = null;
        public int? type_id { get; set; } = null;
        public int? category_id { get; set; } = null;
        public bool is_variation_parent { get; set; }
        public bool is_purchase_product { get; set; }
        public bool is_sales_product { get; set; }
        public double? unit_price { get; set; } = null;
        public double? unit_price_tax_excl { get; set; } = null;
        public double? unit_of_measure { get; set; } = null;
        public bool is_tax_inclusive { get; set; }
        public double? tax_percent { get; set; } = null;
        public double? unit_cost { get; set; } = null;
        public int? currency_id { get; set; } = null;
        public string notes { get; set; } = null;
        public bool? is_stockable { get; set; } = null;
        public int? manufacturer_id { get; set; } = null;
        public string manufacturer_product_number { get; set; } = null;
        public int? supplier_id { get; set; } = null;
        public string warranty_duration { get; set; } = null;
        public string barcode { get; set; } = null;
        public string serial_number { get; set; } = null;
        public int? minimum_quantity { get; set; } = null;
        public int? quantity { get; set; } = null;
        public int? location_id { get; set; } = null;
        public int? parent_product_id { get; set; } = null;
        public string external_id_1 { get; set; } = null;
        public string external_id_2 { get; set; } = null;
        public string external_id_3 { get; set; } = null;
        public int? account_id { get; set; } = null;

    }
}
