using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Tasks : Base
    {
        public string name { get; set; } = null;
        public string description { get; set; } = null;
        public int? type_id { get; set; } = null;
        public DateTime? due_date { get; set; } = null;
        public int? due_value { get; set; } = null;
        public DateTime? reminder_date { get; set; } = null;
        public int? reminder_value { get; set; } = null;
        public int? assigned_to_id { get; set; } = null;
        public bool is_completed { get; set; }
        public DateTime? completed_at { get; set; } = null;
        public int? position { get; set; } = null;
        public int? parent_task_id { get; set; } = null;
        public string external_id_1 { get; set; } = null;
        public string external_id_2 { get; set; } = null;
        public string external_id_3 { get; set; } = null;
        public int? parent_id { get; set; } = null;
        public string parent_type { get; set; } = null;
        public string entity { get; set; } = null;
        public int? entity_id { get; set; } = null;

    }
}
