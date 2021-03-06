using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("users_x_roles")]
    public partial class UsersXRole : EntityBaseNoId
    {
        [Key]
        [Column("user_id", Order = 2)]
        public int UserId { get; set; }
        [Key]
        [Column("account_id", Order = 1)]
        public int AccountId { get; set; }
        [Key]
        [Column("role_id", Order = 0)]
        public int RoleId { get; set; }
        [Column("is_selected")]
        public bool? IsSelected { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("UsersXRoles")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("UsersXRoles")]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UsersXRoles")]
        public virtual User User { get; set; }


    }
}
