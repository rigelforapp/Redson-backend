using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("comments")]
    [Index(nameof(CreatedById), Name = "ix_comments_created_by_id")]
    [Index(nameof(OrderId), Name = "ix_comments_order_id")]
    [Index(nameof(UpdatedById), Name = "ix_comments_updated_by_id")]
    public partial class Comment : Base
    {
        public Comment()
        {
            CommentsXFiles = new HashSet<CommentsXFile>();
        }

        [Column("body")]
        public string Body { get; set; }
        [Column("is_internal")]
        public bool? IsInternal { get; set; }
        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("parent_type")]
        [StringLength(20)]
        public string ParentType { get; set; }
        [Column("order_id")]
        public int? OrderId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.CommentCreatedBies))]
        public virtual User CreatedBy { get; set; }
        
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Comments")]
        public virtual Order Order { get; set; }
        
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.CommentUpdatedBies))]
        public virtual User UpdatedBy { get; set; }
        
        [InverseProperty(nameof(CommentsXFile.Comment))]
        public virtual ICollection<CommentsXFile> CommentsXFiles { get; set; }
    }
}
