using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Currencies : Base
    {
        public bool delete { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string badge { get; set; }
        public string symbol { get; set; }
        public string state { get; set; }
        public string logo { get; set; }
        public int country_id { get; set; }
    }
}
