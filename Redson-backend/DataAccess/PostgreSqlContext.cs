using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Redson_backend.Models;

namespace Redson_backend.DataAccess
{
    public class PostgreSqlContext: DbContext
    {

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Accounts> accounts { get; set; }
        public DbSet<Countries> countries { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<Comments> comments { get; set; }
        public DbSet<Contacts> contacts { get; set; }
        public DbSet<Currencies> currencies { get; set; }
        public DbSet<Files> files { get; set; }
        public DbSet<Groups> groups { get; set; }
        public DbSet<Locations> locations { get; set; }
        public DbSet<OrderHistory> orderHistory { get; set; }
        public DbSet<OrderItems> orderItems { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Organizations> organizations { get; set; }
        public DbSet<PackageItems> packageItems { get; set; }
        public DbSet<Packages> packages { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<Types> types { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Vehicles> vehicles { get; set; }
        public DbSet<VehicleModels> vehicleModels { get; set; }
        public DbSet<VehiclesEquipments> vehiclesEquipments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

    }
}
