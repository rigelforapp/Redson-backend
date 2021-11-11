using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Tasks : Base
    {
        public string name { get; set; }
        public string description { get; set; }
        public int type_id { get; set; }
        public DateTime due_date { get; set; }
        public int due_value { get; set; }
        public DateTime reminder_date { get; set; }
        public int reminder_value { get; set; }
        public int assigned_to_id { get; set; }
        public bool is_completed { get; set; }
        public DateTime completed_at { get; set; }
        public int position { get; set; }
        public int parent_task_id { get; set; }
        public string external_id_1 { get; set; }
        public string external_id_2 { get; set; }
        public string external_id_3 { get; set; }
        public int parent_id { get; set; }
        public string parent_type { get; set; }
        public string entity { get; set; }
        public int entity_id { get; set; }

    }
}
