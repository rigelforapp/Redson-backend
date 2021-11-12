using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class OrderHistory : Base
    {
        public int? order_id { get; set; } = null;
        public string field { get; set; } = null;
        public string new_value { get; set; } = null;
        public string old_value { get; set; } = null;
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int? elapsed_time { get; set; } = null;

    }
}
