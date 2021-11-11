using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Orders : Base
    {
        public string number { get; set; }
        public string name { get; set; }
        public int type_id { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
        public int priority { get; set; }
        public int measure_value_1 { get; set; }
        public string unit_of_measure_1 { get; set; }
        public int measure_value_2 { get; set; }
        public string unit_of_measure_2 { get; set; }
        public string description { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public DateTime planned_start_date { get; set; }
        public DateTime planned_end_date { get; set; }
        public int maintenance_plan_id { get; set; }
        public int vehicle_id { get; set; }
        public int contact_id { get; set; }
        public int organization_id { get; set; }
        public int location_id { get; set; }
        public int account_id { get; set; }
        public double sub_total { get; set; }
        public double discount { get; set; }
        public double tax { get; set; }
        public double total { get; set; }
        public int currency_id { get; set; }
        public int owner_id { get; set; }
        public int technician_id { get; set; }
        public int serviced_by_id { get; set; }
        public int parent_order_id { get; set; }
        public string external_reference { get; set; }
        public string external_id_1 { get; set; }
        public string external_id_2 { get; set; }
        public string external_id_3 { get; set; }
        public string token { get; set; }

    }
}
