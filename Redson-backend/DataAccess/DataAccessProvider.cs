using System;
using System.Collections.Generic;
using System.Linq;
using Redson_backend.Models;
using System.Web;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Redson_backend.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;
        static PostgreSqlContext _scontext;
        private DataAccessProvidesParameters dapp;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
            _scontext = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            dapp = new DataAccessProvidesParameters();
        }

        public PostgreSqlContext GetContext()
        {
            return _context;
        }

        public bool WhereBaseQuery(Base objt)
        {
            //var account_propery = objt.GetType().GetProperty("AccountId");
            //return objt.IsDeleted == false;
            //return (int)account_propery.GetValue(objt, null) == dapp.AccountId;

            var itsAcceptableCondition = true;

            // Filter by Account by Relationship User x Role
            if (dapp.AccountId != 0)
            {
                var accountProp = objt.GetType().GetProperty("AccountId");
                if (accountProp != null)
                {
                    var AccountId = accountProp.GetValue(objt);

                    if (AccountId != null)
                    {
                        if (Int32.Parse(AccountId.ToString()) != dapp.AccountId)
                        {
                            return false;
                        }
                    }
                    else {
                        return false;
                    }
                    
                }
            }

            if (dapp.q == "")
            {
                for (int i = 0; i < dapp.PropName.Length; i++)
                {
                    var propNameAux = char.ToUpper(dapp.PropName[i][0]) + dapp.PropName[i].Substring(1);
                    var propName = objt.GetType().GetProperty(propNameAux);

                    if (propName != null)
                    {
                        var value = propName.GetValue(objt);

                        if (value != null)
                        {
                            value = value.ToString();
                            var queryStringValue = System.Web.HttpUtility.UrlDecode(dapp.PropValue[i]);
                            itsAcceptableCondition &= value.Equals(queryStringValue);
                        }
                        else {
                            itsAcceptableCondition = false;
                        }
                    }

                }
            }
            else {
                itsAcceptableCondition = false;
                foreach (PropertyInfo propertyInfo in objt.GetType().GetProperties())
                {
                    if (propertyInfo.PropertyType.Name == "String")
                    {
                        var propertyValue = propertyInfo.GetValue(objt);
                        if (propertyValue!=null)
                        {
                            itsAcceptableCondition = propertyValue.ToString().ToLower().Contains(dapp.q);

                            if(itsAcceptableCondition)
                            {
                                break;
                            }
                        }
                        
                    }
                }
            }

            

            return itsAcceptableCondition;
        }

        #region Account

        public List<Account> GetAccountRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.account.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Country> GetCountryRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.country.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Category> GetCategoryRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.category.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Comment> GetCommentRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.comment.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Contact> GetContactRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.contact
                .Include( c => c.Photo )
                .Include( c => c.Organization )
                .Include( c => c.Organization.Photo )
                .Include( c => c.Owner)
                .Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
        }

        public Contact GetContactRecord(int Id)
        {
            return _context.contact
                .Include(c => c.Photo)
                .Include(c => c.Organization)
                .Include(c => c.Organization.Photo)
                .Include(c => c.Owner)
                .FirstOrDefault(t => t.Id == Id);
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

        public List<Currency> GetCurrencyRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.currency.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<File> GetFileRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.file.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Group> GetGroupRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.group.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Location> GetLocationRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.location.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        #region Manufacturer

        public List<Manufacturer> GetManufacturerRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.manufacturer.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
        }

        public Manufacturer GetManufacturerRecord(int Id)
        {
            return _context.manufacturer.FirstOrDefault(t => t.Id == Id);
        }

        public void AddManufacturerRecord(Manufacturer manufacturer)
        {
            _context.manufacturer.Add(manufacturer);
            _context.SaveChanges();
        }

        public void UpdateManufacturerRecord(Manufacturer manufacturer)
        {
            _context.manufacturer.Update(manufacturer);
            _context.SaveChanges();
        }
        public void DeleteManufacturerRecord(int Id)
        {
            var entity = _context.manufacturer.FirstOrDefault(t => t.Id == Id);
            _context.manufacturer.Remove(entity);
            _context.SaveChanges();
        }

        #endregion Location

        #region OrderHistory

        public List<OrderHistory> GetOrderHistoryRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.orderHistory.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<OrderItem> GetOrderItemRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.orderItem.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Order> GetOrderRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;

            /*return _context.order
                .Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();*/

            return _context.order
                .Include(o => o.Organization)
                .Include(o => o.Contact)
                .Include(o => o.Vehicle)
                .Include(o => o.Vehicle.Photo)
                .Include(o => o.Owner)
                .Include(o => o.Technician)
                .Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
        }

        public Order GetOrderRecord(int Id)
        {
            return _context.order
                .Include(o => o.Organization)
                .Include(o => o.Contact)
                .Include(o => o.Vehicle)
                .Include(o => o.Vehicle.Photo)
                .Include(o => o.Owner)
                .Include(o => o.Technician)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Technician )
                .FirstOrDefault(t => t.Id == Id);
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

        public List<Organization> GetOrganizationRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.organization
                .Include( o => o.Photo )
                .Include( o => o.Owner )
                .Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
        }

        public Organization GetOrganizationRecord(int Id)
        {
            return _context.organization
                .Include(o => o.Photo)
                .Include(o => o.Owner)
                .FirstOrDefault(t => t.Id == Id);
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

        public List<PackageItem> GetPackageItemRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.packageItem.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Package> GetPackageRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.package.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Product> GetProductRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.product.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Role> GetRoleRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.role.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Task> GetTaskRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.task.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<Redson_backend.Models.Type> GetTypeRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.type.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

        public List<User> GetUserRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.user.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
        }

        public User GetUserRecord(int Id)
        {
            return _context.user.FirstOrDefault(t => t.Id == Id);
        }

        public User GetUserByUserAndPassRecord(string username, string password)
        {
            return _scontext.user.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            //return _scontext.user.Where(BaseQuery).FirstOrDefault();
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

        #region UserXRole

        public List<UsersXRole> GetUsersXRoleRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.userxrole.Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
        }

        public UsersXRole GetUsersXRoleRecord(UsersXRole userXRol)
        {
            return _context.userxrole.FirstOrDefault( t => t.UserId == userXRol.UserId && t.RoleId == userXRol.RoleId && t.AccountId == userXRol.AccountId  );
        }

        public void AddUsersXRoleRecord(UsersXRole user)
        {
            _context.userxrole.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUsersXRoleRecord(UsersXRole userXRol)
        {
            _context.userxrole.Update(userXRol);
            _context.SaveChanges();
        }

        public void DeleteUsersXRoleRecord(int UserId)
        {
            var entity = _context.userxrole.FirstOrDefault(t => t.UserId == UserId);
            _context.userxrole.Remove(entity);
            _context.SaveChanges();
        }

        #endregion User

        #region Vehicle

        public List<Vehicle> GetVehicleRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.vehicle
                .Include(v => v.Photo)
                .Include(v => v.Group)
                .Include(v => v.VehicleModel)
                .Include(v => v.Type)
                .Include(v => v.Organization)
                .Include(v => v.Organization.Photo)
                .Include(v => v.Contact)
                .Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
        }

        public Vehicle GetVehicleRecord(int Id)
        {
            var vehicle = _context.vehicle
                .Include(v => v.Photo)
                .Include(v => v.Group)
                .Include(v => v.VehicleModel)
                .Include(v => v.Type)
                .Include(v => v.Organization)
                .Include(v => v.Contact)
                .Include(v => v.Orders)
                .FirstOrDefault(t => t.Id == Id);

            

            dapp = new DataAccessProvidesParameters();

            Array.Resize(ref dapp.PropName, dapp.PropName.Length + 1);
            dapp.PropName[dapp.PropName.GetUpperBound(0)] = "parentType";

            Array.Resize(ref dapp.PropValue, dapp.PropValue.Length + 1);
            dapp.PropValue[dapp.PropValue.GetUpperBound(0)] = "vehicle";

            Array.Resize(ref dapp.PropName, dapp.PropName.Length + 1);
            dapp.PropName[dapp.PropName.GetUpperBound(0)] = "parentId";

            Array.Resize(ref dapp.PropValue, dapp.PropValue.Length + 1);
            dapp.PropValue[dapp.PropValue.GetUpperBound(0)] = vehicle.Id.ToString();

            // Tasks

            vehicle.Tasks = GetTaskRecords(dapp);

            // Files

            vehicle.Files = GetFileRecords(dapp);

            return vehicle;
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

        public List<VehicleModel> GetVehicleModelRecords(DataAccessProvidesParameters dapp)
        {
            this.dapp = dapp;
            return _context.vehicleModel.Where(WhereBaseQuery).Skip(dapp.PageSkip).Take(dapp.PageSize).ToList();
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

    public class DataAccessProvidesParameters
    {
        // Pagination
        public int PageSize = int.MaxValue;
        public int PageNumber = 0;
        public int PageSkip = 0;

        // Account ID
        public int AccountId = 0;

        // Search by property
        public string[] PropName;
        public string[] PropValue;

        // Search by q
        public string q = "";

        public DataAccessProvidesParameters() {
            PropName = new string[0];
            PropValue = new string[0];
        }
    }
}