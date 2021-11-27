using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("roles")]
    public partial class Role : Base
    {
        public Role()
        {
            //UsersXRoles = new HashSet<UsersXRole>();
        }

        [Key]
        [Column("id")]
        public int? Id { get; set; } = null;
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        /*[InverseProperty(nameof(UsersXRole.Role))]
        public virtual ICollection<UsersXRole> UsersXRoles { get; set; }*/
    }
}
