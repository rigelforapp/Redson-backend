﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class PackageItems : Base
    {
        public int? package_id { get; set; } = null;
        public string name { get; set; } = null;
        public string description { get; set; } = null;
        public int? product_id { get; set; } = null;
        public double? quantity { get; set; } = null;
        public double? unit_price { get; set; } = null;
        public double? sub_total { get; set; } = null;
        public double? discount { get; set; } = null;
        public double? tax_percent { get; set; } = null;
        public double? tax_amount { get; set; } = null;
        public double? total { get; set; } = null;
        public int? parent_item_id { get; set; } = null;
        public int? position { get; set; } = null;
        public bool is_separator { get; set; }
    }
}
