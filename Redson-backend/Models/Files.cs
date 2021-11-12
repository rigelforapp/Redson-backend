using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redson_backend.Models
{
    public class Files : Base
    {
        public string filename { get; set; } = null;
        public string mime_type { get; set; } = null;
        public int? size { get; set; } = null;
        public string content_url { get; set; } = null;
        public string thumbnail_url { get; set; } = null;
        public string description { get; set; } = null;
        public int? external_id { get; set; } = null;
        public int? comment_id { get; set; } = null;
        public int? parent_id { get; set; } = null;
        public string parent_type { get; set; } = null;
    }
}
