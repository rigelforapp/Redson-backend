using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Contacts : Base
    {
        public string name { get; set; } = null;
        public string first_name { get; set; } = null;
        public string last_name { get; set; } = null;
        public string phone { get; set; } = null;
        public string mobile_phone { get; set; } = null;
        public string email { get; set; } = null;
        public string job_title { get; set; } = null;
        public DateTime birth_date { get; set; }
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
        public int? group_id { get; set; } = null;
        public int? user_id { get; set; } = null;
        public bool is_primary_contact { get; set; }
        public string source { get; set; } = null;
        public string external_id_1 { get; set; } = null;
        public string external_id_2 { get; set; } = null;
        public string external_id_3 { get; set; } = null;
        public int? owner_id { get; set; } = null;
        public int? organization_id { get; set; } = null;
        public int? account_id { get; set; } = null;
    }
}
