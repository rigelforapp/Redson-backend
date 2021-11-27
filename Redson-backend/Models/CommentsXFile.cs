using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("comments_x_files")]
    public partial class CommentsXFile : Base
    {
        //[Key]
        [Column("comment_id")]
        public int CommentId { get; set; }
        //[Key]
        [Column("file_id")]
        public int FileId { get; set; }

        /*[ForeignKey(nameof(CommentId))]
        [InverseProperty("CommentsXFiles")]
        public virtual Comment Comment { get; set; }
        [ForeignKey(nameof(FileId))]
        [InverseProperty("CommentsXFiles")]
        public virtual File File { get; set; }*/
    }
}
