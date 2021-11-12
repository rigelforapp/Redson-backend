using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Users : Base
    {
        public string name { get; set; } = null;
        public string email { get; set; } = null;
        public string username { get; set; } = null;
        public string password { get; set; } = null;
        public string type { get; set; } = null;
        public string phone { get; set; } = null;
        public string session_token { get; set; } = null;

    }
}
