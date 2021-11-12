using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Redson_backend.Models
{
    public class Base
    {
        public int? id { get; set; } = null;
        public bool? is_active { get; set; } = null;
        public bool? is_deleted { get; set; } = null;
        public int? created_by_id { get; set; } = null;
        public DateTime? created_at { get; set; } = null;
        public int? updated_by_id { get; set; } = null;
        public DateTime? updated_at { get; set; } = null;
    }
}
