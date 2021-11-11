using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Categories : Base
    {
        public string name { get; set; }
        public string entity { get; set; }
        public int parent_category_id { get; set; }
        public int account_id { get; set; }
            
    }
}
