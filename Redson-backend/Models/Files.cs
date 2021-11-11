using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Files : Base
    {
        public string filename { get; set; }
        public string mime_type { get; set; }
        public int size { get; set; }
        public string content_url { get; set; }
        public string thumbnail_url { get; set; }
        public string description { get; set; }
        public int external_id { get; set; }
        public int comment_id { get; set; }
        public int parent_id { get; set; }
        public string parent_type { get; set; }
    }
}
