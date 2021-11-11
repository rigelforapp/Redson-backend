using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Products : Base
    {
        public string number { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int type_id { get; set; }
        public int category_id { get; set; }
        public bool is_variation_parent { get; set; }
        public bool is_purchase_product { get; set; }
        public bool is_sales_product { get; set; }
        public double unit_price { get; set; }
        public double unit_price_tax_excl { get; set; }
        public double unit_of_measure { get; set; }
        public bool is_tax_inclusive { get; set; }
        public double tax_percent { get; set; }
        public double unit_cost { get; set; }
        public int currency_id { get; set; }
        public string notes { get; set; }
        public bool is_stockable { get; set; }
        public int manufacturer_id { get; set; }
        public string manufacturer_product_number { get; set; }
        public int supplier_id { get; set; }
        public string warranty_duration { get; set; }
        public string barcode { get; set; }
        public string serial_number { get; set; }
        public int minimum_quantity { get; set; }
        public int quantity { get; set; }
        public int location_id { get; set; }
        public int parent_product_id { get; set; }
        public string external_id_1 { get; set; }
        public string external_id_2 { get; set; }
        public string external_id_3 { get; set; }
        public int account_id { get; set; }

    }
}
