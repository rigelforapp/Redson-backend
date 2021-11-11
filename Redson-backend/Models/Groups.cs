using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Groups : Base
    {
        public int organization_id { get; set; }
        public int account_id { get; set; }
        public string name { get; set; }
        public int type_id { get; set; }
        public string description { get; set; }
        public int parent_group_id { get; set; }


    }
}
