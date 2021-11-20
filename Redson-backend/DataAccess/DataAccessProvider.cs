using System;
using System.Collections.Generic;
using System.Linq;
using Redson_backend.Models;

namespace Redson_backend.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;
        static PostgreSqlContext _scontext;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
            _scontext = context;
        }

        #region Account

        public List<Account> GetAccountRecords()
        {
            return _context.account.ToList();
        }

        public Account GetAccountRecord(int Id)
        {
            return _context.account.FirstOrDefault(t => t.Id == Id);
        }

        public void AddAccountRecord(Account account)
        {
            _context.account.Add(account);
            _context.SaveChanges();
        }

        public void UpdateAccountRecord(Account account)
        {
            _context.account.Update(account);
            _context.SaveChanges();
        }
        public void DeleteAccountRecord(int Id)
        {
            var entity = _context.account.FirstOrDefault(t => t.Id == Id);
            _context.account.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Account

        #region Country

        public List<Country> GetCountryRecords()
        {
            return _context.country.ToList();
        }

        public Country GetCountryRecord(int Id)
        {
            return _context.country.FirstOrDefault(t => t.Id == Id);
        }

        public void AddCountryRecord(Country country)
        {
            _context.country.Add(country);
            _context.SaveChanges();
        }

        public void UpdateCountryRecord(Country country)
        {
            _context.country.Update(country);
            _context.SaveChanges();
        }
        public void DeleteCountryRecord(int Id)
        {
            var entity = _context.country.FirstOrDefault(t => t.Id == Id);
            _context.country.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Country

        #region Category

        public List<Category> GetCategoryRecords()
        {
            return _context.category.ToList();
        }

        public Category GetCategoryRecord(int Id)
        {
            return _context.category.FirstOrDefault(t => t.Id == Id);
        }

        public void AddCategoryRecord(Category category)
        {
            _context.category.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategoryRecord(Category category)
        {
            _context.category.Update(category);
            _context.SaveChanges();
        }
        public void DeleteCategoryRecord(int Id)
        {
            var entity = _context.category.FirstOrDefault(t => t.Id == Id);
            _context.category.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Category

        #region Comment

        public List<Comment> GetCommentRecords()
        {
            return _context.comment.ToList();
        }

        public Comment GetCommentRecord(int Id)
        {
            return _context.comment.FirstOrDefault(t => t.Id == Id);
        }

        public void AddCommentRecord(Comment comment)
        {
            _context.comment.Add(comment);
            _context.SaveChanges();
        }

        public void UpdateCommentRecord(Comment comment)
        {
            _context.comment.Update(comment);
            _context.SaveChanges();
        }
        public void DeleteCommentRecord(int Id)
        {
            var entity = _context.comment.FirstOrDefault(t => t.Id == Id);
            _context.comment.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Comment

        #region Contact

        public List<Contact> GetContactRecords()
        {
            return _context.contact.ToList();
        }

        public Contact GetContactRecord(int Id)
        {
            return _context.contact.FirstOrDefault(t => t.Id == Id);
        }

        public void AddContactRecord(Contact contact)
        {
            _context.contact.Add(contact);
            _context.SaveChanges();
        }

        public void UpdateContactRecord(Contact contact)
        {
            _context.contact.Update(contact);
            _context.SaveChanges();
        }
        public void DeleteContactRecord(int Id)
        {
            var entity = _context.contact.FirstOrDefault(t => t.Id == Id);
            _context.contact.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Contact

        #region Currency

        public List<Currency> GetCurrencyRecords()
        {
            return _context.currency.ToList();
        }

        public Currency GetCurrencyRecord(int Id)
        {
            return _context.currency.FirstOrDefault(t => t.Id == Id);
        }

        public void AddCurrencyRecord(Currency currency)
        {
            _context.currency.Add(currency);
            _context.SaveChanges();
        }

        public void UpdateCurrencyRecord(Currency currency)
        {
            _context.currency.Update(currency);
            _context.SaveChanges();
        }
        public void DeleteCurrencyRecord(int Id)
        {
            var entity = _context.currency.FirstOrDefault(t => t.Id == Id);
            _context.currency.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Currency

        #region File

        public List<File> GetFileRecords()
        {
            return _context.file.ToList();
        }

        public File GetFileRecord(int Id)
        {
            return _context.file.FirstOrDefault(t => t.Id == Id);
        }

        public void AddFileRecord(File file)
        {
            _context.file.Add(file);
            _context.SaveChanges();
        }

        public void UpdateFileRecord(File file)
        {
            _context.file.Update(file);
            _context.SaveChanges();
        }
        public void DeleteFileRecord(int Id)
        {
            var entity = _context.file.FirstOrDefault(t => t.Id == Id);
            _context.file.Remove(entity);
            _context.SaveChanges();
        }

        #endregion File

        #region Group

        public List<Group> GetGroupRecords()
        {
            return _context.group.ToList();
        }

        public Group GetGroupRecord(int Id)
        {
            return _context.group.FirstOrDefault(t => t.Id == Id);
        }

        public void AddGroupRecord(Group group)
        {
            _context.group.Add(group);
            _context.SaveChanges();
        }

        public void UpdateGroupRecord(Group group)
        {
            _context.group.Update(group);
            _context.SaveChanges();
        }
        public void DeleteGroupRecord(int Id)
        {
            var entity = _context.group.FirstOrDefault(t => t.Id == Id);
            _context.group.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Group

        #region Location

        public List<Location> GetLocationRecords()
        {
            return _context.location.ToList();
        }

        public Location GetLocationRecord(int Id)
        {
            return _context.location.FirstOrDefault(t => t.Id == Id);
        }

        public void AddLocationRecord(Location location)
        {
            _context.location.Add(location);
            _context.SaveChanges();
        }

        public void UpdateLocationRecord(Location location)
        {
            _context.location.Update(location);
            _context.SaveChanges();
        }
        public void DeleteLocationRecord(int Id)
        {
            var entity = _context.location.FirstOrDefault(t => t.Id == Id);
            _context.location.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Location

        #region OrderHistory

        public List<OrderHistory> GetOrderHistoryRecords()
        {
            return _context.orderHistory.ToList();
        }

        public OrderHistory GetOrderHistoryRecord(int Id)
        {
            return _context.orderHistory.FirstOrDefault(t => t.Id == Id);
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
        public void DeleteOrderHistoryRecord(int Id)
        {
            var entity = _context.orderHistory.FirstOrDefault(t => t.Id == Id);
            _context.orderHistory.Remove(entity);
            _context.SaveChanges();
        }

        #endregion OrderHistory

        #region OrderItem

        public List<OrderItem> GetOrderItemRecords()
        {
            return _context.orderItem.ToList();
        }

        public OrderItem GetOrderItemRecord(int Id)
        {
            return _context.orderItem.FirstOrDefault(t => t.Id == Id);
        }

        public void AddOrderItemRecord(OrderItem orderItem)
        {
            _context.orderItem.Add(orderItem);
            _context.SaveChanges();
        }

        public void UpdateOrderItemRecord(OrderItem orderItem)
        {
            _context.orderItem.Update(orderItem);
            _context.SaveChanges();
        }
        public void DeleteOrderItemRecord(int Id)
        {
            var entity = _context.orderItem.FirstOrDefault(t => t.Id == Id);
            _context.orderItem.Remove(entity);
            _context.SaveChanges();
        }

        #endregion OrderItem

        #region Order

        public List<Order> GetOrderRecords()
        {
            return _context.order.ToList();
        }

        public Order GetOrderRecord(int Id)
        {
            return _context.order.FirstOrDefault(t => t.Id == Id);
        }

        public void AddOrderRecord(Order order)
        {
            _context.order.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrderRecord(Order order)
        {
            _context.order.Update(order);
            _context.SaveChanges();
        }
        public void DeleteOrderRecord(int Id)
        {
            var entity = _context.order.FirstOrDefault(t => t.Id == Id);
            _context.order.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Order

        #region Organization

        public List<Organization> GetOrganizationRecords()
        {
            return _context.organization.ToList();
        }

        public Organization GetOrganizationRecord(int Id)
        {
            return _context.organization.FirstOrDefault(t => t.Id == Id);
        }

        public void AddOrganizationRecord(Organization organization)
        {
            _context.organization.Add(organization);
            _context.SaveChanges();
        }

        public void UpdateOrganizationRecord(Organization organization)
        {
            _context.organization.Update(organization);
            _context.SaveChanges();
        }
        public void DeleteOrganizationRecord(int Id)
        {
            var entity = _context.organization.FirstOrDefault(t => t.Id == Id);
            _context.organization.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Organization

        #region PackageItem

        public List<PackageItem> GetPackageItemRecords()
        {
            return _context.packageItem.ToList();
        }

        public PackageItem GetPackageItemRecord(int Id)
        {
            return _context.packageItem.FirstOrDefault(t => t.Id == Id);
        }

        public void AddPackageItemRecord(PackageItem packageItem)
        {
            _context.packageItem.Add(packageItem);
            _context.SaveChanges();
        }

        public void UpdatePackageItemRecord(PackageItem packageItem)
        {
            _context.packageItem.Update(packageItem);
            _context.SaveChanges();
        }
        public void DeletePackageItemRecord(int Id)
        {
            var entity = _context.packageItem.FirstOrDefault(t => t.Id == Id);
            _context.packageItem.Remove(entity);
            _context.SaveChanges();
        }

        #endregion PackageItem

        #region Package

        public List<Package> GetPackageRecords()
        {
            return _context.package.ToList();
        }

        public Package GetPackageRecord(int Id)
        {
            return _context.package.FirstOrDefault(t => t.Id == Id);
        }

        public void AddPackageRecord(Package package)
        {
            _context.package.Add(package);
            _context.SaveChanges();
        }

        public void UpdatePackageRecord(Package package)
        {
            _context.package.Update(package);
            _context.SaveChanges();
        }
        public void DeletePackageRecord(int Id)
        {
            var entity = _context.package.FirstOrDefault(t => t.Id == Id);
            _context.package.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Package

        #region Product

        public List<Product> GetProductRecords()
        {
            return _context.product.ToList();
        }

        public Product GetProductRecord(int Id)
        {
            return _context.product.FirstOrDefault(t => t.Id == Id);
        }

        public void AddProductRecord(Product product)
        {
            _context.product.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProductRecord(Product product)
        {
            _context.product.Update(product);
            _context.SaveChanges();
        }
        public void DeleteProductRecord(int Id)
        {
            var entity = _context.product.FirstOrDefault(t => t.Id == Id);
            _context.product.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Product

        #region Role

        public List<Role> GetRoleRecords()
        {
            return _context.role.ToList();
        }

        public Role GetRoleRecord(int Id)
        {
            return _context.role.FirstOrDefault(t => t.Id == Id);
        }

        public void AddRoleRecord(Role role)
        {
            _context.role.Add(role);
            _context.SaveChanges();
        }

        public void UpdateRoleRecord(Role role)
        {
            _context.role.Update(role);
            _context.SaveChanges();
        }
        public void DeleteRoleRecord(int Id)
        {
            var entity = _context.role.FirstOrDefault(t => t.Id == Id);
            _context.role.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Role

        #region Task

        public List<Task> GetTaskRecords()
        {
            return _context.task.ToList();
        }

        public Task GetTaskRecord(int Id)
        {
            return _context.task.FirstOrDefault(t => t.Id == Id);
        }

        public void AddTaskRecord(Task task)
        {
            _context.task.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTaskRecord(Task task)
        {
            _context.task.Update(task);
            _context.SaveChanges();
        }
        public void DeleteTaskRecord(int Id)
        {
            var entity = _context.task.FirstOrDefault(t => t.Id == Id);
            _context.task.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Task

        #region Type

        public List<Redson_backend.Models.Type> GetTypeRecords()
        {
            return _context.type.ToList();
        }

        public Redson_backend.Models.Type GetTypeRecord(int Id)
        {
            return _context.type.FirstOrDefault(t => t.Id == Id);
        }

        public void AddTypeRecord(Redson_backend.Models.Type type)
        {
            _context.type.Add(type);
            _context.SaveChanges();
        }

        public void UpdateTypeRecord(Redson_backend.Models.Type type)
        {
            _context.type.Update(type);
            _context.SaveChanges();
        }
        public void DeleteTypeRecord(int Id)
        {
            var entity = _context.type.FirstOrDefault(t => t.Id == Id);
            _context.type.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Type

        #region User

        public List<User> GetUserRecords()
        {
            return _context.user.ToList();
        }

        public User GetUserRecord(int Id)
        {
            return _context.user.FirstOrDefault(t => t.Id == Id);
        }

        public static User GetUserByUserAndPassRecord(string username, string password)
        {
            return _scontext.user.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }

        public void AddUserRecord(User user)
        {
            _context.user.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUserRecord(User user)
        {
            _context.user.Update(user);
            _context.SaveChanges();
        }
        public void DeleteUserRecord(int Id)
        {
            var entity = _context.user.FirstOrDefault(t => t.Id == Id);
            _context.user.Remove(entity);
            _context.SaveChanges();
        }

        #endregion User

        #region Vehicle

        public List<Vehicle> GetVehicleRecords()
        {
            return _context.vehicle.ToList();
        }

        public Vehicle GetVehicleRecord(int Id)
        {
            return _context.vehicle.FirstOrDefault(t => t.Id == Id);
        }

        public void AddVehicleRecord(Vehicle vehicle)
        {
            _context.vehicle.Add(vehicle);
            _context.SaveChanges();
        }

        public void UpdateVehicleRecord(Vehicle vehicle)
        {
            _context.vehicle.Update(vehicle);
            _context.SaveChanges();
        }
        public void DeleteVehicleRecord(int Id)
        {
            var entity = _context.vehicle.FirstOrDefault(t => t.Id == Id);
            _context.vehicle.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Vehicle

        #region VehicleModel

        public List<VehicleModel> GetVehicleModelRecords()
        {
            return _context.vehicleModel.ToList();
        }

        public VehicleModel GetVehicleModelRecord(int Id)
        {
            return _context.vehicleModel.FirstOrDefault(t => t.Id == Id);
        }

        public void AddVehicleModelRecord(VehicleModel vehicleModel)
        {
            _context.vehicleModel.Add(vehicleModel);
            _context.SaveChanges();
        }

        public void UpdateVehicleModelRecord(VehicleModel vehicleModel)
        {
            _context.vehicleModel.Update(vehicleModel);
            _context.SaveChanges();
        }
        public void DeleteVehicleModelRecord(int Id)
        {
            var entity = _context.vehicleModel.FirstOrDefault(t => t.Id == Id);
            _context.vehicleModel.Remove(entity);
            _context.SaveChanges();
        }

        #endregion VehicleModel
    }


}
