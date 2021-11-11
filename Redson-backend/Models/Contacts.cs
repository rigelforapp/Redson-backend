using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Contacts : Base
    {
        public  string name { get; set; }
        public  string first_name { get; set; }
        public  string last_name { get; set; }
        public  string phone { get; set; }
        public  string mobile_phone { get; set; }
        public  string email { get; set; }
        public  string job_title { get; set; }
        public DateTime birth_date { get; set; }
        public string address { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string coordinates { get; set; }
        public string website { get; set; }
        public string description { get; set; }
        public int photo_id { get; set; }
        public int group_id { get; set; }
        public int user_id { get; set; }
        public bool is_primary_contact { get; set; }
        public string source { get; set; }
        public string external_id_1 { get; set; }
        public string external_id_2 { get; set; }
        public string external_id_3 { get; set; }
        public int owner_id { get; set; }
        public int organization_id { get; set; }
        public int account_id { get; set; }
    }
}
