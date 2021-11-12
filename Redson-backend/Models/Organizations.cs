using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Organizations : Base
    {
        public string name { get; set; } = null;
        public string type { get; set; } = null;
        public int? category_id { get; set; } = null;
        public string status { get; set; } = null;
        public string industry { get; set; } = null;
        public string phone { get; set; } = null;
        public string mobile_phone { get; set; } = null;
        public string email { get; set; } = null;
        public string billing_name { get; set; } = null;
        public string billing_tax_number { get; set; } = null;
        public string address { get; set; } = null;
        public string address_2 { get; set; } = null;
        public string city { get; set; } = null;
        public string state { get; set; } = null;
        public string postal_code { get; set; } = null;
        public string country { get; set; } = null;
        public string coordinates { get; set; } = null;
        public string website { get; set; } = null;
        public string description { get; set; } = null;
        public int? photo_id { get; set; } = null;
        public string source { get; set; } = null;
        public string external_id_1 { get; set; } = null;
        public string external_id_2 { get; set; } = null;
        public string external_id_3 { get; set; } = null;
        public double? product_discount { get; set; } = null;
        public double? service_discount { get; set; } = null;
        public int? owner_id { get; set; } = null;
        public int? account_id { get; set; } = null;



    }
}
