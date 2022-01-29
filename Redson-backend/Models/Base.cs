using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Redson_backend.Models
{
    public class Base : EntityBaseNoId
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; } = null;
    }
}
