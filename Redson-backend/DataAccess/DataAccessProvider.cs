using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.Models;

namespace Redson_backend.DataAccess
{
    public class DataAccessProvider: IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        #region Accounts

        public List<Accounts> GetAccountsRecords()
        {
            return _context.accounts.ToList();
        }

        public Accounts GetAccountRecord(int id)
        {
            return _context.accounts.FirstOrDefault(t => t.id== id);
        }

        public void AddAccountRecord(Accounts accounts)
        {
            _context.accounts.Add(accounts);
            _context.SaveChanges();
        }

        public void UpdateAccountRecord(Accounts accounts)
        {
            _context.accounts.Update(accounts);
            _context.SaveChanges();
        }
        public void DeleteAccountRecord(int id)
        {
            var entity = _context.accounts.FirstOrDefault(t => t.id == id);
            _context.accounts.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Accounts

        #region Countries

        public List<Countries> GetCountriesRecords()
        {
            return _context.countries.ToList();
        }

        public Countries GetCountryRecord(int id)
        {
            return _context.countries.FirstOrDefault(t => t.id == id);
        }

        public void AddCountryRecord(Countries countries)
        {
            _context.countries.Add(countries);
            _context.SaveChanges();
        }

        public void UpdateCountryRecord(Countries countries)
        {
            _context.countries.Update(countries);
            _context.SaveChanges();
        }
        public void DeleteCountryRecord(int id)
        {
            var entity = _context.countries.FirstOrDefault(t => t.id == id);
            _context.countries.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Countries

        #region Categories

        public List<Categories> GetCategoriesRecords()
        {
            return _context.categories.ToList();
        }

        public Categories GetCategoryRecord(int id)
        {
            return _context.categories.FirstOrDefault(t => t.id == id);
        }

        public void AddCategoryRecord(Categories categories)
        {
            _context.categories.Add(categories);
            _context.SaveChanges();
        }

        public void UpdateCategoryRecord(Categories categories)
        {
            _context.categories.Update(categories);
            _context.SaveChanges();
        }
        public void DeleteCategoryRecord(int id)
        {
            var entity = _context.categories.FirstOrDefault(t => t.id == id);
            _context.categories.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Categories

        #region Comments

        public List<Comments> GetCommentsRecords()
        {
            return _context.comments.ToList();
        }

        public Comments GetCommentRecord(int id)
        {
            return _context.comments.FirstOrDefault(t => t.id == id);
        }

        public void AddCommentRecord(Comments comments)
        {
            _context.comments.Add(comments);
            _context.SaveChanges();
        }

        public void UpdateCommentRecord(Comments comments)
        {
            _context.comments.Update(comments);
            _context.SaveChanges();
        }
        public void DeleteCommentRecord(int id)
        {
            var entity = _context.comments.FirstOrDefault(t => t.id == id);
            _context.comments.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Comments

        #region Contacts

        public List<Contacts> GetContactsRecords()
        {
            return _context.contacts.ToList();
        }

        public Contacts GetContactRecord(int id)
        {
            return _context.contacts.FirstOrDefault(t => t.id == id);
        }

        public void AddContactRecord(Contacts contacts)
        {
            _context.contacts.Add(contacts);
            _context.SaveChanges();
        }

        public void UpdateContactRecord(Contacts contacts)
        {
            _context.contacts.Update(contacts);
            _context.SaveChanges();
        }
        public void DeleteContactRecord(int id)
        {
            var entity = _context.contacts.FirstOrDefault(t => t.id == id);
            _context.contacts.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Contacts

        #region Currencies

        public List<Currencies> GetCurrenciesRecords()
        {
            return _context.currencies.ToList();
        }

        public Currencies GetCurrencyRecord(int id)
        {
            return _context.currencies.FirstOrDefault(t => t.id == id);
        }

        public void AddCurrencyRecord(Currencies currencies)
        {
            _context.currencies.Add(currencies);
            _context.SaveChanges();
        }

        public void UpdateCurrencyRecord(Currencies currencies)
        {
            _context.currencies.Update(currencies);
            _context.SaveChanges();
        }
        public void DeleteCurrencyRecord(int id)
        {
            var entity = _context.currencies.FirstOrDefault(t => t.id == id);
            _context.currencies.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Currencies

        #region Files

        public List<Files> GetFilesRecords()
        {
            return _context.files.ToList();
        }

        public Files GetFileRecord(int id)
        {
            return _context.files.FirstOrDefault(t => t.id == id);
        }

        public void AddFileRecord(Files files)
        {
            _context.files.Add(files);
            _context.SaveChanges();
        }

        public void UpdateFileRecord(Files files)
        {
            _context.files.Update(files);
            _context.SaveChanges();
        }
        public void DeleteFileRecord(int id)
        {
            var entity = _context.files.FirstOrDefault(t => t.id == id);
            _context.files.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Files

        #region Groups

        public List<Groups> GetGroupsRecords()
        {
            return _context.groups.ToList();
        }

        public Groups GetGroupRecord(int id)
        {
            return _context.groups.FirstOrDefault(t => t.id == id);
        }

        public void AddGroupRecord(Groups groups)
        {
            _context.groups.Add(groups);
            _context.SaveChanges();
        }

        public void UpdateGroupRecord(Groups groups)
        {
            _context.groups.Update(groups);
            _context.SaveChanges();
        }
        public void DeleteGroupRecord(int id)
        {
            var entity = _context.groups.FirstOrDefault(t => t.id == id);
            _context.groups.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Groups

        #region Locations

        public List<Locations> GetLocationsRecords()
        {
            return _context.locations.ToList();
        }

        public Locations GetLocationRecord(int id)
        {
            return _context.locations.FirstOrDefault(t => t.id == id);
        }

        public void AddLocationRecord(Locations locations)
        {
            _context.locations.Add(locations);
            _context.SaveChanges();
        }

        public void UpdateLocationRecord(Locations locations)
        {
            _context.locations.Update(locations);
            _context.SaveChanges();
        }
        public void DeleteLocationRecord(int id)
        {
            var entity = _context.locations.FirstOrDefault(t => t.id == id);
            _context.locations.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Locations

        #region OrderHistory

        public List<OrderHistory> GetOrderHistoryRecords()
        {
            return _context.orderHistory.ToList();
        }

        public OrderHistory GetOrderHistoryRecord(int id)
        {
            return _context.orderHistory.FirstOrDefault(t => t.id == id);
        }

        public void AddOrderHistoryRecord(OrderHistory orderHistory)
        {
            _context.orderHistory.Add(orderHistory);
            _context.SaveChanges();
        }

        public void UpdateOrderHistoryRecord(OrderHistory orderHistory)
        {
            _context.orderHistory.Update(orderHistory);
            _context.SaveChanges();
        }
        public void DeleteOrderHistoryRecord(int id)
        {
            var entity = _context.orderHistory.FirstOrDefault(t => t.id == id);
            _context.orderHistory.Remove(entity);
            _context.SaveChanges();
        }

        #endregion OrderHistory

        #region OrderItems

        public List<OrderItems> GetOrderItemsRecords()
        {
            return _context.orderItems.ToList();
        }

        public OrderItems GetOrderItemRecord(int id)
        {
            return _context.orderItems.FirstOrDefault(t => t.id == id);
        }

        public void AddOrderItemRecord(OrderItems orderItems)
        {
            _context.orderItems.Add(orderItems);
            _context.SaveChanges();
        }

        public void UpdateOrderItemRecord(OrderItems orderItems)
        {
            _context.orderItems.Update(orderItems);
            _context.SaveChanges();
        }
        public void DeleteOrderItemRecord(int id)
        {
            var entity = _context.orderItems.FirstOrDefault(t => t.id == id);
            _context.orderItems.Remove(entity);
            _context.SaveChanges();
        }

        #endregion OrderItems

        #region Orders

        public List<Orders> GetOrdersRecords()
        {
            return _context.orders.ToList();
        }

        public Orders GetOrderRecord(int id)
        {
            return _context.orders.FirstOrDefault(t => t.id == id);
        }

        public void AddOrderRecord(Orders orders)
        {
            _context.orders.Add(orders);
            _context.SaveChanges();
        }

        public void UpdateOrderRecord(Orders orders)
        {
            _context.orders.Update(orders);
            _context.SaveChanges();
        }
        public void DeleteOrderRecord(int id)
        {
            var entity = _context.orders.FirstOrDefault(t => t.id == id);
            _context.orders.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Orders

        #region Organizations

        public List<Organizations> GetOrganizationsRecords()
        {
            return _context.organizations.ToList();
        }

        public Organizations GetOrganizationRecord(int id)
        {
            return _context.organizations.FirstOrDefault(t => t.id == id);
        }

        public void AddOrganizationRecord(Organizations organizations)
        {
            _context.organizations.Add(organizations);
            _context.SaveChanges();
        }

        public void UpdateOrganizationRecord(Organizations organizations)
        {
            _context.organizations.Update(organizations);
            _context.SaveChanges();
        }
        public void DeleteOrganizationRecord(int id)
        {
            var entity = _context.organizations.FirstOrDefault(t => t.id == id);
            _context.organizations.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Organizations

        #region PackageItems

        public List<PackageItems> GetPackageItemsRecords()
        {
            return _context.packageItems.ToList();
        }

        public PackageItems GetPackageItemRecord(int id)
        {
            return _context.packageItems.FirstOrDefault(t => t.id == id);
        }

        public void AddPackageItemRecord(PackageItems packageItems)
        {
            _context.packageItems.Add(packageItems);
            _context.SaveChanges();
        }

        public void UpdatePackageItemRecord(PackageItems packageItems)
        {
            _context.packageItems.Update(packageItems);
            _context.SaveChanges();
        }
        public void DeletePackageItemRecord(int id)
        {
            var entity = _context.packageItems.FirstOrDefault(t => t.id == id);
            _context.packageItems.Remove(entity);
            _context.SaveChanges();
        }

        #endregion PackageItems

        #region Packages

        public List<Packages> GetPackagesRecords()
        {
            return _context.packages.ToList();
        }

        public Packages GetPackageRecord(int id)
        {
            return _context.packages.FirstOrDefault(t => t.id == id);
        }

        public void AddPackageRecord(Packages packages)
        {
            _context.packages.Add(packages);
            _context.SaveChanges();
        }

        public void UpdatePackageRecord(Packages packages)
        {
            _context.packages.Update(packages);
            _context.SaveChanges();
        }
        public void DeletePackageRecord(int id)
        {
            var entity = _context.packages.FirstOrDefault(t => t.id == id);
            _context.packages.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Packages

        #region Products

        public List<Products> GetProductsRecords()
        {
            return _context.products.ToList();
        }

        public Products GetProductRecord(int id)
        {
            return _context.products.FirstOrDefault(t => t.id == id);
        }

        public void AddProductRecord(Products products)
        {
            _context.products.Add(products);
            _context.SaveChanges();
        }

        public void UpdateProductRecord(Products products)
        {
            _context.products.Update(products);
            _context.SaveChanges();
        }
        public void DeleteProductRecord(int id)
        {
            var entity = _context.products.FirstOrDefault(t => t.id == id);
            _context.products.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Products

        #region Roles

        public List<Roles> GetRolesRecords()
        {
            return _context.roles.ToList();
        }

        public Roles GetRoleRecord(int id)
        {
            return _context.roles.FirstOrDefault(t => t.id == id);
        }

        public void AddRoleRecord(Roles roles)
        {
            _context.roles.Add(roles);
            _context.SaveChanges();
        }

        public void UpdateRoleRecord(Roles roles)
        {
            _context.roles.Update(roles);
            _context.SaveChanges();
        }
        public void DeleteRoleRecord(int id)
        {
            var entity = _context.roles.FirstOrDefault(t => t.id == id);
            _context.roles.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Roles

        #region Tasks

        public List<Tasks> GetTasksRecords()
        {
            return _context.tasks.ToList();
        }

        public Tasks GetTaskRecord(int id)
        {
            return _context.tasks.FirstOrDefault(t => t.id == id);
        }

        public void AddTaskRecord(Tasks tasks)
        {
            _context.tasks.Add(tasks);
            _context.SaveChanges();
        }

        public void UpdateTaskRecord(Tasks tasks)
        {
            _context.tasks.Update(tasks);
            _context.SaveChanges();
        }
        public void DeleteTaskRecord(int id)
        {
            var entity = _context.tasks.FirstOrDefault(t => t.id == id);
            _context.tasks.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Tasks

        #region Types

        public List<Types> GetTypesRecords()
        {
            return _context.types.ToList();
        }

        public Types GetTypeRecord(int id)
        {
            return _context.types.FirstOrDefault(t => t.id == id);
        }

        public void AddTypeRecord(Types types)
        {
            _context.types.Add(types);
            _context.SaveChanges();
        }

        public void UpdateTypeRecord(Types types)
        {
            _context.types.Update(types);
            _context.SaveChanges();
        }
        public void DeleteTypeRecord(int id)
        {
            var entity = _context.types.FirstOrDefault(t => t.id == id);
            _context.types.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Types

        #region Users

        public List<Users> GetUsersRecords()
        {
            return _context.users.ToList();
        }

        public Users GetUserRecord(int id)
        {
            return _context.users.FirstOrDefault(t => t.id == id);
        }

        public void AddUserRecord(Users users)
        {
            _context.users.Add(users);
            _context.SaveChanges();
        }

        public void UpdateUserRecord(Users users)
        {
            _context.users.Update(users);
            _context.SaveChanges();
        }
        public void DeleteUserRecord(int id)
        {
            var entity = _context.users.FirstOrDefault(t => t.id == id);
            _context.users.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Users

        #region Vehicles

        public List<Vehicles> GetVehiclesRecords()
        {
            return _context.vehicles.ToList();
        }

        public Vehicles GetVehicleRecord(int id)
        {
            return _context.vehicles.FirstOrDefault(t => t.id == id);
        }

        public void AddVehicleRecord(Vehicles vehicles)
        {
            _context.vehicles.Add(vehicles);
            _context.SaveChanges();
        }

        public void UpdateVehicleRecord(Vehicles vehicles)
        {
            _context.vehicles.Update(vehicles);
            _context.SaveChanges();
        }
        public void DeleteVehicleRecord(int id)
        {
            var entity = _context.vehicles.FirstOrDefault(t => t.id == id);
            _context.vehicles.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Vehicles

        #region VehicleModels

        public List<VehicleModels> GetVehicleModelsRecords()
        {
            return _context.vehicleModels.ToList();
        }

        public VehicleModels GetVehicleModelRecord(int id)
        {
            return _context.vehicleModels.FirstOrDefault(t => t.id == id);
        }

        public void AddVehicleModelRecord(VehicleModels vehicleModels)
        {
            _context.vehicleModels.Add(vehicleModels);
            _context.SaveChanges();
        }

        public void UpdateVehicleModelRecord(VehicleModels vehicleModels)
        {
            _context.vehicleModels.Update(vehicleModels);
            _context.SaveChanges();
        }
        public void DeleteVehicleModelRecord(int id)
        {
            var entity = _context.vehicleModels.FirstOrDefault(t => t.id == id);
            _context.vehicleModels.Remove(entity);
            _context.SaveChanges();
        }

        #endregion VehicleModels

        #region VehiclesEquipments

        public List<VehiclesEquipments> GetVehiclesEquipmentsRecords()
        {
            return _context.vehiclesEquipments.ToList();
        }

        public VehiclesEquipments GetVehicleEquipmentRecord(int id)
        {
            return _context.vehiclesEquipments.FirstOrDefault(t => t.id == id);
        }

        public void AddVehicleEquipmentRecord(VehiclesEquipments vehiclesEquipments)
        {
            _context.vehiclesEquipments.Add(vehiclesEquipments);
            _context.SaveChanges();
        }

        public void UpdateVehicleEquipmentRecord(VehiclesEquipments vehiclesEquipments)
        {
            _context.vehiclesEquipments.Update(vehiclesEquipments);
            _context.SaveChanges();
        }
        public void DeleteVehicleEquipmentRecord(int id)
        {
            var entity = _context.vehiclesEquipments.FirstOrDefault(t => t.id == id);
            _context.vehiclesEquipments.Remove(entity);
            _context.SaveChanges();
        }

        #endregion VehiclesEquipments
    }
}
