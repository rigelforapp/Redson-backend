using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Locations : Base
    {
        public string name { get; set; }
        public string description { get; set; }
        public string is_inventory_location { get; set; }
        public int parent_location_id { get; set; }
        public int owner_id { get; set; }
        public int account_id { get; set; }


    }
}
