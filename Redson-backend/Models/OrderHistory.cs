using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class OrderHistory : Base
    {
        public int order_id { get; set; }
        public string field { get; set; }
        public string new_value { get; set; }
        public string old_value { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int elapsed_time { get; set; }

    }
}
