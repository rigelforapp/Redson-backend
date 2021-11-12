using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Locations : Base
    {
        public string name { get; set; } = null;
        public string description { get; set; } = null;
        public string is_inventory_location { get; set; } = null;
        public int? parent_location_id { get; set; } = null;
        public int? owner_id { get; set; } = null;
        public int? account_id { get; set; } = null;


    }
}
