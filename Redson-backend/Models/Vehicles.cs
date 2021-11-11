using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Vehicles : Base
    {
        public string number { get; set; }
        public string name { get; set; }
        public string registration_number { get; set; }
        public int type_id { get; set; }
        public int manufacturer_model_id { get; set; }
        public string version { get; set; }
        public int manufactured_year { get; set; }
        public int group_id { get; set; }
        public string status { get; set; }
        public int measure_value_1 { get; set; }
        public string unit_of_measure_1 { get; set; }
        public int measure_value_2 { get; set; }
        public string unit_of_measure_2 { get; set; }
        public string external_id_1 { get; set; }
        public string external_id_2 { get; set; }
        public string external_id_3 { get; set; }
        public int photo_id { get; set; }
        public string serial_number { get; set; }
        public string fuel_type { get; set; }
        public string description { get; set; }
        public int parent_vehicle_id { get; set; }
        public int owner_id { get; set; }
        public DateTime last_service { get; set; }
        public DateTime next_service { get; set; }
        public int contact_id { get; set; }
        public int organization_id { get; set; }
        public int account_id { get; set; }


    }
}
