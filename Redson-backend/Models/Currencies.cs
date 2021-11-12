using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Currencies : Base
    {
        public bool delete { get; set; }
        public string code { get; set; } = null;
        public string name { get; set; } = null;
        public string badge { get; set; } = null;
        public string symbol { get; set; } = null;
        public string state { get; set; } = null;
        public string logo { get; set; } = null;
        public int? country_id { get; set; } = null;
    }
}
