using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Redson_backend.Models
{
    [Table("types")]
    public partial class Type : Base
    {
        public Type()
        {
            Accounts = new HashSet<Account>();
            Groups = new HashSet<Group>();
            Manufacturers = new HashSet<Manufacturer>();
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            Tasks = new HashSet<Task>();
            Vehicles = new HashSet<Vehicle>();
        }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("entity")]
        [StringLength(50)]
        public string Entity { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }

        [InverseProperty(nameof(Account.Type))]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty(nameof(Group.Type))]
        public virtual ICollection<Group> Groups { get; set; }
        [InverseProperty(nameof(Manufacturer.Type))]
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }
        [InverseProperty(nameof(Order.Type))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(Product.Type))]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty(nameof(Task.Type))]
        public virtual ICollection<Task> Tasks { get; set; }
        [InverseProperty(nameof(Vehicle.Type))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
