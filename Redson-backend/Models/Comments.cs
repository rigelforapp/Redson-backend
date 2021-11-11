using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Comments : Base
    {
        public string body { get; set; }
        public bool is_internal { get; set; }
        public int parent_id { get; set; }
        public string parent_type { get; set; }
        public int order_id { get; set; }
        public int account_id { get; set; }
    }
}
