using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

#nullable disable

namespace Redson_backend.Models
{
    [Table("users")]
    [Index(nameof(CreatedById), Name = "ix_users_created_by_id")]
    [Index(nameof(UpdatedById), Name = "ix_users_updated_by_id")]
    public partial class User : Base
    {
        public User()
        {
            AccountCreatedBies = new HashSet<Account>();
            AccountUpdatedBies = new HashSet<Account>();
            CommentCreatedBies = new HashSet<Comment>();
            CommentUpdatedBies = new HashSet<Comment>();
            ContactCreatedBies = new HashSet<Contact>();
            ContactUpdatedBies = new HashSet<Contact>();
            ContactUsers = new HashSet<Contact>();
            CountryCreatedBies = new HashSet<Country>();
            CountryUpdatedBies = new HashSet<Country>();
            CurrencyCreatedBies = new HashSet<Currency>();
            CurrencyUpdatedBies = new HashSet<Currency>();
            GroupCreatedBies = new HashSet<Group>();
            GroupUpdatedBies = new HashSet<Group>();
            InverseCreatedBy = new HashSet<User>();
            InverseUpdatedBy = new HashSet<User>();
            LocationCreatedBies = new HashSet<Location>();
            LocationUpdatedBies = new HashSet<Location>();
            OrderCreatedBies = new HashSet<Order>();
            OrderHistoryCreatedBies = new HashSet<OrderHistory>();
            OrderHistoryUpdatedBies = new HashSet<OrderHistory>();
            OrderItemCreatedBies = new HashSet<OrderItem>();
            OrderItemTechnicians = new HashSet<OrderItem>();
            OrderItemUpdatedBies = new HashSet<OrderItem>();
            OrderOwners = new HashSet<Order>();
            OrderTechnicians = new HashSet<Order>();
            OrderUpdatedBies = new HashSet<Order>();
            OrganizationCreatedBies = new HashSet<Organization>();
            OrganizationUpdatedBies = new HashSet<Organization>();
            PackageCreatedBies = new HashSet<Package>();
            PackageItemCreatedBies = new HashSet<PackageItem>();
            PackageItemUpdatedBies = new HashSet<PackageItem>();
            PackageUpdatedBies = new HashSet<Package>();
            ProductCreatedBies = new HashSet<Product>();
            ProductUpdatedBies = new HashSet<Product>();
            Tasks = new HashSet<Task>();
            UsersXRoles = new HashSet<UsersXRole>();
            VehicleCreatedBies = new HashSet<Vehicle>();
            VehicleUpdatedBies = new HashSet<Vehicle>();
            
            Organizations = new HashSet<Organization>();
            ContactOwners = new HashSet<Contact>();
        }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("username")]
        [StringLength(255)]
        public string Username { get; set; }
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }
        [Column("type")]
        [StringLength(255)]
        public string Type { get; set; }
        [Column("phone")]
        [StringLength(255)]
        public string Phone { get; set; }
        [Column("session_token")]
        [StringLength(255)]
        public string SessionToken { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.InverseCreatedBy))]
        public virtual User CreatedBy { get; set; }
        
        [ForeignKey(nameof(UpdatedById))]
        [InverseProperty(nameof(User.InverseUpdatedBy))]
        public virtual User UpdatedBy { get; set; }
        
        [InverseProperty(nameof(Account.CreatedBy))]
        public virtual ICollection<Account> AccountCreatedBies { get; set; }
        
        [InverseProperty(nameof(Account.UpdatedBy))]
        public virtual ICollection<Account> AccountUpdatedBies { get; set; }
        
        [InverseProperty(nameof(Comment.CreatedBy))]
        public virtual ICollection<Comment> CommentCreatedBies { get; set; }
        
        [InverseProperty(nameof(Comment.UpdatedBy))]
        public virtual ICollection<Comment> CommentUpdatedBies { get; set; }
        
        [InverseProperty(nameof(Contact.CreatedBy))]
        public virtual ICollection<Contact> ContactCreatedBies { get; set; }
        
        [InverseProperty(nameof(Contact.UpdatedBy))]
        public virtual ICollection<Contact> ContactUpdatedBies { get; set; }
        
        [InverseProperty(nameof(Contact.User))]
        public virtual ICollection<Contact> ContactUsers { get; set; }
        
        [InverseProperty(nameof(Country.CreatedBy))]
        public virtual ICollection<Country> CountryCreatedBies { get; set; }
        
        [InverseProperty(nameof(Country.UpdatedBy))]
        public virtual ICollection<Country> CountryUpdatedBies { get; set; }
        
        [InverseProperty(nameof(Currency.CreatedBy))]
        public virtual ICollection<Currency> CurrencyCreatedBies { get; set; }
        
        [InverseProperty(nameof(Currency.UpdatedBy))]
        public virtual ICollection<Currency> CurrencyUpdatedBies { get; set; }
        
        [InverseProperty(nameof(Group.CreatedBy))]
        public virtual ICollection<Group> GroupCreatedBies { get; set; }
        
        [InverseProperty(nameof(Group.UpdatedBy))]
        public virtual ICollection<Group> GroupUpdatedBies { get; set; }
        
        [InverseProperty(nameof(User.CreatedBy))]
        public virtual ICollection<User> InverseCreatedBy { get; set; }
        
        [InverseProperty(nameof(User.UpdatedBy))]
        public virtual ICollection<User> InverseUpdatedBy { get; set; }
        
        [InverseProperty(nameof(Location.CreatedBy))]
        public virtual ICollection<Location> LocationCreatedBies { get; set; }
        
        [InverseProperty(nameof(Location.UpdatedBy))]
        public virtual ICollection<Location> LocationUpdatedBies { get; set; }
        
        [InverseProperty(nameof(Order.CreatedBy))]
        public virtual ICollection<Order> OrderCreatedBies { get; set; }
        
        [InverseProperty(nameof(OrderHistory.CreatedBy))]
        public virtual ICollection<OrderHistory> OrderHistoryCreatedBies { get; set; }
        
        [InverseProperty(nameof(OrderHistory.UpdatedBy))]
        public virtual ICollection<OrderHistory> OrderHistoryUpdatedBies { get; set; }
        
        [InverseProperty(nameof(OrderItem.CreatedBy))]
        public virtual ICollection<OrderItem> OrderItemCreatedBies { get; set; }

        [InverseProperty(nameof(OrderItem.Technician))]
        public virtual ICollection<OrderItem> OrderItemTechnicians { get; set; }

        [InverseProperty(nameof(OrderItem.UpdatedBy))]
        public virtual ICollection<OrderItem> OrderItemUpdatedBies { get; set; }

        [InverseProperty(nameof(Order.Owner))]
        public virtual ICollection<Order> OrderOwners { get; set; }

        [InverseProperty(nameof(Order.Technician))]
        public virtual ICollection<Order> OrderTechnicians { get; set; }

        [InverseProperty(nameof(Order.UpdatedBy))]
        public virtual ICollection<Order> OrderUpdatedBies { get; set; }

        [InverseProperty(nameof(Organization.CreatedBy))]
        public virtual ICollection<Organization> OrganizationCreatedBies { get; set; }

        [InverseProperty(nameof(Organization.UpdatedBy))]
        public virtual ICollection<Organization> OrganizationUpdatedBies { get; set; }

        [InverseProperty(nameof(Package.CreatedBy))]
        public virtual ICollection<Package> PackageCreatedBies { get; set; }

        [InverseProperty(nameof(PackageItem.CreatedBy))]
        public virtual ICollection<PackageItem> PackageItemCreatedBies { get; set; }

        [InverseProperty(nameof(PackageItem.UpdatedBy))]
        public virtual ICollection<PackageItem> PackageItemUpdatedBies { get; set; }

        [InverseProperty(nameof(Package.UpdatedBy))]
        public virtual ICollection<Package> PackageUpdatedBies { get; set; }

        [InverseProperty(nameof(Product.CreatedBy))]
        public virtual ICollection<Product> ProductCreatedBies { get; set; }

        [InverseProperty(nameof(Product.UpdatedBy))]
        public virtual ICollection<Product> ProductUpdatedBies { get; set; }

        [InverseProperty(nameof(Task.AssignedTo))]
        public virtual ICollection<Task> Tasks { get; set; }

        [InverseProperty(nameof(UsersXRole.User))]
        public virtual ICollection<UsersXRole> UsersXRoles { get; set; }

        [InverseProperty(nameof(Vehicle.CreatedBy))]
        public virtual ICollection<Vehicle> VehicleCreatedBies { get; set; }

        [InverseProperty(nameof(Vehicle.UpdatedBy))]
        public virtual ICollection<Vehicle> VehicleUpdatedBies { get; set; }

        [InverseProperty(nameof(Organization.Owner))]
        public virtual ICollection<Organization> Organizations { get; set; }

        [InverseProperty(nameof(Contact.Owner))]
        public virtual ICollection<Contact> ContactOwners { get; set; }
    }
}
