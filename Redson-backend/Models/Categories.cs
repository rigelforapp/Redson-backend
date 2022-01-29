using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("categories")]
    public partial class Category : Base
    {
        public Category()
        {
            Accounts = new HashSet<Account>();
            Organizations = new HashSet<Organization>();
            Products = new HashSet<Product>();
        }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("entity")]
        [StringLength(50)]
        public string Entity { get; set; }
        [Column("parent_category_id")]
        public int? ParentCategoryId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        [InverseProperty(nameof(Account.Category))]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty(nameof(Organization.Category))]
        public virtual ICollection<Organization> Organizations { get; set; }
        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
