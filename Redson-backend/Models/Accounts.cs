using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Accounts : Base
    {
        public string name { get; set; }
        public int? type_id { get; set; } = null;
        public int? category_id { get; set; } = null;
        public string phone { get; set; } = null;
        public string mobile_phone { get; set; } = null;
        public string email { get; set; } = null;
        public string billing_tax_number { get; set; } = null;
        public string address { get; set; } = null;
        public string address_2 { get; set; } = null;
        public string city { get; set; } = null;
        public string state { get; set; } = null;
        public string postal_code { get; set; } = null;
        public string website { get; set; } = null;
        public string description { get; set; } = null;
        public int? photo_id { get; set; } = null;
        public int? time_zone { get; set; } = null;
        public double? tax_percent { get; set; } = null;
        public int? currency_id { get; set; } = null;
    }
}
