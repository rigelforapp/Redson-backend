using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.Models;

namespace Redson_backend.DataAccess
{
    public interface IDataAccessProvider
    {
        List<Account> GetAccountRecords();
        Account GetAccountRecord(int id);
        void AddAccountRecord(Account accounts);
        void UpdateAccountRecord(Account accounts);
        void DeleteAccountRecord(int id);

        List<Country> GetCountryRecords();
        Country GetCountryRecord(int id);
        void AddCountryRecord(Country accounts);
        void UpdateCountryRecord(Country accounts);
        void DeleteCountryRecord(int id);

        List<Category> GetCategoryRecords();
        Category GetCategoryRecord(int id);
        void AddCategoryRecord(Category accounts);
        void UpdateCategoryRecord(Category accounts);
        void DeleteCategoryRecord(int id);

        List<Comment> GetCommentRecords();
        Comment GetCommentRecord(int id);
        void AddCommentRecord(Comment accounts);
        void UpdateCommentRecord(Comment accounts);
        void DeleteCommentRecord(int id);

        List<Contact> GetContactRecords();
        Contact GetContactRecord(int id);
        void AddContactRecord(Contact accounts);
        void UpdateContactRecord(Contact accounts);
        void DeleteContactRecord(int id);

        List<Currency> GetCurrencyRecords();
        Currency GetCurrencyRecord(int id);
        void AddCurrencyRecord(Currency accounts);
        void UpdateCurrencyRecord(Currency accounts);
        void DeleteCurrencyRecord(int id);

        List<File> GetFileRecords();
        File GetFileRecord(int id);
        void AddFileRecord(File accounts);
        void UpdateFileRecord(File accounts);
        void DeleteFileRecord(int id);

        List<Group> GetGroupRecords();
        Group GetGroupRecord(int id);
        void AddGroupRecord(Group accounts);
        void UpdateGroupRecord(Group accounts);
        void DeleteGroupRecord(int id);

        List<Location> GetLocationRecords();
        Location GetLocationRecord(int id);
        void AddLocationRecord(Location accounts);
        void UpdateLocationRecord(Location accounts);
        void DeleteLocationRecord(int id);

        List<OrderHistory> GetOrderHistoryRecords();
        OrderHistory GetOrderHistoryRecord(int id);
        void AddOrderHistoryRecord(OrderHistory accounts);
        void UpdateOrderHistoryRecord(OrderHistory accounts);
        void DeleteOrderHistoryRecord(int id);

        List<OrderItem> GetOrderItemRecords();
        OrderItem GetOrderItemRecord(int id);
        void AddOrderItemRecord(OrderItem accounts);
        void UpdateOrderItemRecord(OrderItem accounts);
        void DeleteOrderItemRecord(int id);

        List<Order> GetOrderRecords();
        Order GetOrderRecord(int id);
        void AddOrderRecord(Order accounts);
        void UpdateOrderRecord(Order accounts);
        void DeleteOrderRecord(int id);

        List<Organization> GetOrganizationRecords();
        Organization GetOrganizationRecord(int id);
        void AddOrganizationRecord(Organization accounts);
        void UpdateOrganizationRecord(Organization accounts);
        void DeleteOrganizationRecord(int id);

        List<PackageItem> GetPackageItemRecords();
        PackageItem GetPackageItemRecord(int id);
        void AddPackageItemRecord(PackageItem accounts);
        void UpdatePackageItemRecord(PackageItem accounts);
        void DeletePackageItemRecord(int id);

        List<Package> GetPackageRecords();
        Package GetPackageRecord(int id);
        void AddPackageRecord(Package accounts);
        void UpdatePackageRecord(Package accounts);
        void DeletePackageRecord(int id);

        List<Product> GetProductRecords();
        Product GetProductRecord(int id);
        void AddProductRecord(Product accounts);
        void UpdateProductRecord(Product accounts);
        void DeleteProductRecord(int id);

        List<Role> GetRoleRecords();
        Role GetRoleRecord(int id);
        void AddRoleRecord(Role accounts);
        void UpdateRoleRecord(Role accounts);
        void DeleteRoleRecord(int id);

        List<Redson_backend.Models.Task> GetTaskRecords();
        Redson_backend.Models.Task GetTaskRecord(int id);
        void AddTaskRecord(Redson_backend.Models.Task accounts);
        void UpdateTaskRecord(Redson_backend.Models.Task accounts);
        void DeleteTaskRecord(int id);

        List<Redson_backend.Models.Type> GetTypeRecords();
        Redson_backend.Models.Type GetTypeRecord(int id);
        void AddTypeRecord(Redson_backend.Models.Type accounts);
        void UpdateTypeRecord(Redson_backend.Models.Type accounts);
        void DeleteTypeRecord(int id);

        List<User> GetUserRecords();
        User GetUserRecord(int id);
        void AddUserRecord(User accounts);
        void UpdateUserRecord(User accounts);
        void DeleteUserRecord(int id);

        List<Vehicle> GetVehicleRecords();
        Vehicle GetVehicleRecord(int id);
        void AddVehicleRecord(Vehicle accounts);
        void UpdateVehicleRecord(Vehicle accounts);
        void DeleteVehicleRecord(int id);

        List<VehicleModel> GetVehicleModelRecords();
        VehicleModel GetVehicleModelRecord(int id);
        void AddVehicleModelRecord(VehicleModel accounts);
        void UpdateVehicleModelRecord(VehicleModel accounts);
        void DeleteVehicleModelRecord(int id);
    }
}
