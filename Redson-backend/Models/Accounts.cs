using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Accounts : Base
    {
        public string name { get; set; }
        public int type_id { get; set; }
        public int category_id { get; set; }
        public string phone { get; set; }
        public string mobile_phone { get; set; }
        public string email { get; set; }
        public string billing_tax_number { get; set; }
        public string address { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string website { get; set; }
        public string description { get; set; }
        public int photo_id { get; set; }
        public int time_zone { get; set; }
        public double tax_percent { get; set; }
        public int currency_id { get; set; }
    }
}
