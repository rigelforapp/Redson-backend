using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Redson_backend.Models
{
    public class Base
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; } = null;
        [Column("is_active")]
        public bool? IsActive { get; set; }
        [Column("is_deleted")]
        public bool? IsDeleted { get; set; }
        [Column("created_by_id")]
        public int? CreatedById { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = null;
        [Column("updated_by_id")]
        public int? UpdatedById { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
