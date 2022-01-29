using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.Models;

namespace Redson_backend.DataAccess
{
    public interface IDataAccessProvider
    {
        PostgreSqlContext GetContext();

        List<Account> GetAccountRecords(DataAccessProvidesParameters dapp);
        Account GetAccountRecord(int id);
        void AddAccountRecord(Account accounts);
        void UpdateAccountRecord(Account accounts);
        void DeleteAccountRecord(int id);

        List<Country> GetCountryRecords(DataAccessProvidesParameters dapp);
        Country GetCountryRecord(int id);
        void AddCountryRecord(Country accounts);
        void UpdateCountryRecord(Country accounts);
        void DeleteCountryRecord(int id);

        List<Category> GetCategoryRecords(DataAccessProvidesParameters dapp);
        Category GetCategoryRecord(int id);
        void AddCategoryRecord(Category accounts);
        void UpdateCategoryRecord(Category accounts);
        void DeleteCategoryRecord(int id);

        List<Comment> GetCommentRecords(DataAccessProvidesParameters dapp);
        Comment GetCommentRecord(int id);
        void AddCommentRecord(Comment accounts);
        void UpdateCommentRecord(Comment accounts);
        void DeleteCommentRecord(int id);

        List<Contact> GetContactRecords(DataAccessProvidesParameters dapp);
        Contact GetContactRecord(int id);
        void AddContactRecord(Contact accounts);
        void UpdateContactRecord(Contact accounts);
        void DeleteContactRecord(int id);

        List<Currency> GetCurrencyRecords(DataAccessProvidesParameters dapp);
        Currency GetCurrencyRecord(int id);
        void AddCurrencyRecord(Currency accounts);
        void UpdateCurrencyRecord(Currency accounts);
        void DeleteCurrencyRecord(int id);

        List<File> GetFileRecords(DataAccessProvidesParameters dapp);
        File GetFileRecord(int id);
        void AddFileRecord(File accounts);
        void UpdateFileRecord(File accounts);
        void DeleteFileRecord(int id);

        List<Group> GetGroupRecords(DataAccessProvidesParameters dapp);
        Group GetGroupRecord(int id);
        void AddGroupRecord(Group accounts);
        void UpdateGroupRecord(Group accounts);
        void DeleteGroupRecord(int id);

        List<Location> GetLocationRecords(DataAccessProvidesParameters dapp);
        Location GetLocationRecord(int id);
        void AddLocationRecord(Location accounts);
        void UpdateLocationRecord(Location accounts);
        void DeleteLocationRecord(int id);

        List<Manufacturer> GetManufacturerRecords(DataAccessProvidesParameters dapp);
        Manufacturer GetManufacturerRecord(int id);
        void AddManufacturerRecord(Manufacturer accounts);
        void UpdateManufacturerRecord(Manufacturer accounts);
        void DeleteManufacturerRecord(int id);

        List<OrderHistory> GetOrderHistoryRecords(DataAccessProvidesParameters dapp);
        OrderHistory GetOrderHistoryRecord(int id);
        void AddOrderHistoryRecord(OrderHistory accounts);
        void UpdateOrderHistoryRecord(OrderHistory accounts);
        void DeleteOrderHistoryRecord(int id);

        List<OrderItem> GetOrderItemRecords(DataAccessProvidesParameters dapp);
        OrderItem GetOrderItemRecord(int id);
        void AddOrderItemRecord(OrderItem accounts);
        void UpdateOrderItemRecord(OrderItem accounts);
        void DeleteOrderItemRecord(int id);

        List<Order> GetOrderRecords(DataAccessProvidesParameters dapp);
        Order GetOrderRecord(int id);
        void AddOrderRecord(Order accounts);
        void UpdateOrderRecord(Order accounts);
        void DeleteOrderRecord(int id);

        List<Organization> GetOrganizationRecords(DataAccessProvidesParameters dapp);
        Organization GetOrganizationRecord(int id);
        void AddOrganizationRecord(Organization accounts);
        void UpdateOrganizationRecord(Organization accounts);
        void DeleteOrganizationRecord(int id);

        List<PackageItem> GetPackageItemRecords(DataAccessProvidesParameters dapp);
        PackageItem GetPackageItemRecord(int id);
        void AddPackageItemRecord(PackageItem accounts);
        void UpdatePackageItemRecord(PackageItem accounts);
        void DeletePackageItemRecord(int id);

        List<Package> GetPackageRecords(DataAccessProvidesParameters dapp);
        Package GetPackageRecord(int id);
        void AddPackageRecord(Package accounts);
        void UpdatePackageRecord(Package accounts);
        void DeletePackageRecord(int id);

        List<Product> GetProductRecords(DataAccessProvidesParameters dapp);
        Product GetProductRecord(int id);
        void AddProductRecord(Product accounts);
        void UpdateProductRecord(Product accounts);
        void DeleteProductRecord(int id);

        List<Role> GetRoleRecords(DataAccessProvidesParameters dapp);
        Role GetRoleRecord(int id);
        void AddRoleRecord(Role accounts);
        void UpdateRoleRecord(Role accounts);
        void DeleteRoleRecord(int id);

        List<Redson_backend.Models.Task> GetTaskRecords(DataAccessProvidesParameters dapp);
        Redson_backend.Models.Task GetTaskRecord(int id);
        void AddTaskRecord(Redson_backend.Models.Task accounts);
        void UpdateTaskRecord(Redson_backend.Models.Task accounts);
        void DeleteTaskRecord(int id);

        List<Redson_backend.Models.Type> GetTypeRecords(DataAccessProvidesParameters dapp);
        Redson_backend.Models.Type GetTypeRecord(int id);
        void AddTypeRecord(Redson_backend.Models.Type accounts);
        void UpdateTypeRecord(Redson_backend.Models.Type accounts);
        void DeleteTypeRecord(int id);

        List<User> GetUserRecords(DataAccessProvidesParameters dapp);
        User GetUserRecord(int id);
        void AddUserRecord(User accounts);
        void UpdateUserRecord(User accounts);
        void DeleteUserRecord(int id);

        List<UsersXRole> GetUsersXRoleRecords(DataAccessProvidesParameters dapp);
        UsersXRole GetUsersXRoleRecord(UsersXRole usersXRole);
        void AddUsersXRoleRecord(UsersXRole accounts);
        void UpdateUsersXRoleRecord(UsersXRole accounts);
        void DeleteUsersXRoleRecord(int id);

        List<Vehicle> GetVehicleRecords(DataAccessProvidesParameters dapp);
        Vehicle GetVehicleRecord(int id);
        void AddVehicleRecord(Vehicle accounts);
        void UpdateVehicleRecord(Vehicle accounts);
        void DeleteVehicleRecord(int id);

        List<VehicleModel> GetVehicleModelRecords(DataAccessProvidesParameters dapp);
        VehicleModel GetVehicleModelRecord(int id);
        void AddVehicleModelRecord(VehicleModel accounts);
        void UpdateVehicleModelRecord(VehicleModel accounts);
        void DeleteVehicleModelRecord(int id);
    }
}
