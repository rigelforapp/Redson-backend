﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Packages : Base
    {
        public string number { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int account_id { get; set; }
    }
}
