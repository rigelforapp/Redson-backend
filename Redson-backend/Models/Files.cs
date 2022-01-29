using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("files")]
    public partial class File : Base
    {
        public File()
        {
            Accounts = new HashSet<Account>();
            Organizations = new HashSet<Organization>();
            CommentsXFiles = new HashSet<CommentsXFile>();
            Contacts = new HashSet<Contact>();
            Vehicles = new HashSet<Vehicle>();
        }

        /*[Key]
        [Column("id")]
        public int? Id { get; set; } = null;*/
        [Column("filename")]
        [StringLength(255)]
        public string Filename { get; set; }
        [Column("mime_type")]
        [StringLength(255)]
        public string MimeType { get; set; }
        [Column("size")]
        public short? Size { get; set; }
        [Column("content_url")]
        public string ContentUrl { get; set; }
        [Column("thumbnail_url")]
        public string ThumbnailUrl { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("external_id")]
        public int? ExternalId { get; set; }
        [Column("comment_id")]
        public int? CommentId { get; set; }
        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("parent_type")]
        [StringLength(20)]
        public string ParentType { get; set; }
        [Column("as3_key")]
        [StringLength(512)]
        public string As3Key { get; set; }

        [InverseProperty(nameof(Account.Photo))]
        public virtual ICollection<Account> Accounts { get; set; }
        
        [InverseProperty(nameof(Organization.Photo))]
        public virtual ICollection<Organization> Organizations { get; set; }
        
        [InverseProperty(nameof(CommentsXFile.File))]
        public virtual ICollection<CommentsXFile> CommentsXFiles { get; set; }

        [InverseProperty(nameof(Contact.Photo))]
        public virtual ICollection<Contact> Contacts { get; set; }

        [InverseProperty(nameof(Vehicle.Photo))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
