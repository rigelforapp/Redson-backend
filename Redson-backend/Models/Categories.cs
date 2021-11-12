using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Categories : Base
    {
        public string name { get; set; } = null;
        public string entity { get; set; } = null;
        public int? parent_category_id { get; set; } = null;
        public int? account_id { get; set; } = null;

    }
}
