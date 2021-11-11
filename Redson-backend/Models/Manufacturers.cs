using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Manufacturers : Base
    {
        public string name { get; set; }
        public int logo_id { get; set; }
        public Boolean is_vehicle_manufacturer { get; set; }
        public int type_id { get; set; }
        public int account_id { get; set; }
    }
}
