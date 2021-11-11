using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class PackageItems : Base
    {
        public int package_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int product_id { get; set; }
        public double quantity { get; set; }
        public double unit_price { get; set; }
        public double sub_total { get; set; }
        public double discount { get; set; }
        public double tax_percent { get; set; }
        public double tax_amount { get; set; }
        public double total { get; set; }
        public int parent_item_id { get; set; }
        public int position { get; set; }
        public bool is_separator { get; set; }
    }
}
