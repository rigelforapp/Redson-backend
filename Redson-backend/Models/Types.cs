using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Types : Base
    {
        public string name { get; set; } = null;
        public string entity { get; set; } = null;
        public string account_id { get; set; } = null;
    }
}
