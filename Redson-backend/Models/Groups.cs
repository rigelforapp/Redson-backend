using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Groups : Base
    {
        public int? organization_id { get; set; } = null;
        public int? account_id { get; set; } = null;
        public string name { get; set; } = null;
        public int? type_id { get; set; } = null;
        public string description { get; set; }
        public int? parent_group_id { get; set; } = null;


    }
}
