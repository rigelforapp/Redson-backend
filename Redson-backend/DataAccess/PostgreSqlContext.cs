using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Redson_backend.Models;
using System.Data;

namespace Redson_backend.DataAccess
{
    public class PostgreSqlContext: DbContext
    {

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Account> account { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Comment> comment { get; set; }
        public DbSet<Contact> contact { get; set; }
        public DbSet<Currency> currency { get; set; }
        public DbSet<File> file { get; set; }
        public DbSet<Group> group { get; set; }
        public DbSet<Location> location { get; set; }
        public DbSet<Manufacturer> manufacturer { get; set; }
        public DbSet<OrderHistory> orderHistory { get; set; }
        public DbSet<OrderItem> orderItem { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Organization> organization { get; set; }
        public DbSet<PackageItem> packageItem { get; set; }
        public DbSet<Package> package { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Redson_backend.Models.Task> task { get; set; }
        public DbSet<Redson_backend.Models.Type> type { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<UsersXRole> userxrole { get; set; }
        public DbSet<Vehicle> vehicle { get; set; }
        public DbSet<VehicleModel> vehicleModel { get; set; }
        public DbSet<VehiclesEquipments> vehiclesEquipment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            builder.Entity<UsersXRole>()
                .HasKey(e => new { e.RoleId, e.UserId, e.AccountId });
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

    }
}
