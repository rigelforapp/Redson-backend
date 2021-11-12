using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Packages : Base
    {
        public string number { get; set; } = null;
        public string name { get; set; } = null;
        public string description { get; set; } = null;
        public int? account_id { get; set; } = null;
    }
}
