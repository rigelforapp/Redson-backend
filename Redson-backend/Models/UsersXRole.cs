using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("users_x_roles")]
    public partial class UsersXRole
    {
        //[Key]
        [Column("user_id")]
        public int UserId { get; set; }
        //[Key]
        [Column("account_id")]
        public int AccountId { get; set; }
        [Key]
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("is_active")]
        public bool? IsActive { get; set; }
        [Column("is_deleted")]
        public bool? IsDeleted { get; set; }
        [Column("created_by_id")]
        public int? CreatedById { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_by_id")]
        public int? UpdatedById { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

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
