using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Orders : Base
    {
        public string number { get; set; } = null;
        public string name { get; set; } = null;
        public int? type_id { get; set; } = null;
        public string status { get; set; } = null;
        public DateTime date { get; set; }
        public int? priority { get; set; } = null;
        public int? measure_value_1 { get; set; } = null;
        public string unit_of_measure_1 { get; set; } = null;
        public int? measure_value_2 { get; set; } = null;
        public string unit_of_measure_2 { get; set; } = null;
        public string description { get; set; } = null;
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public DateTime planned_start_date { get; set; }
        public DateTime planned_end_date { get; set; }
        public int? maintenance_plan_id { get; set; } = null;
        public int? vehicle_id { get; set; } = null;
        public int? contact_id { get; set; } = null;
        public int? organization_id { get; set; } = null;
        public int? location_id { get; set; } = null;
        public int? account_id { get; set; } = null;
        public double? sub_total { get; set; } = null;
        public double? discount { get; set; } = null;
        public double? tax { get; set; } = null;
        public double? total { get; set; } = null;
        public int? currency_id { get; set; } = null;
        public int? owner_id { get; set; } = null;
        public int? technician_id { get; set; } = null;
        public int? serviced_by_id { get; set; } = null;
        public int? parent_order_id { get; set; } = null;
        public string external_reference { get; set; } = null;
        public string external_id_1 { get; set; } = null;
        public string external_id_2 { get; set; } = null;
        public string external_id_3 { get; set; } = null;
        public string token { get; set; } = null;

    }
}
