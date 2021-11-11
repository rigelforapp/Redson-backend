using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.Models;

namespace Redson_backend.DataAccess
{
    public interface IDataAccessProvider
    {
        List<Accounts> GetAccountsRecords();
        Accounts GetAccountRecord(int id);
        void AddAccountRecord(Accounts accounts);
        void UpdateAccountRecord(Accounts accounts);
        void DeleteAccountRecord(int id);

        List<Countries> GetCountriesRecords();
        Countries GetCountryRecord(int id);
        void AddCountryRecord(Countries accounts);
        void UpdateCountryRecord(Countries accounts);
        void DeleteCountryRecord(int id);

        List<Categories> GetCategoriesRecords();
        Categories GetCategoryRecord(int id);
        void AddCategoryRecord(Categories accounts);
        void UpdateCategoryRecord(Categories accounts);
        void DeleteCategoryRecord(int id);

        List<Comments> GetCommentsRecords();
        Comments GetCommentRecord(int id);
        void AddCommentRecord(Comments accounts);
        void UpdateCommentRecord(Comments accounts);
        void DeleteCommentRecord(int id);

        List<Contacts> GetContactsRecords();
        Contacts GetContactRecord(int id);
        void AddContactRecord(Contacts accounts);
        void UpdateContactRecord(Contacts accounts);
        void DeleteContactRecord(int id);

        List<Currencies> GetCurrenciesRecords();
        Currencies GetCurrencyRecord(int id);
        void AddCurrencyRecord(Currencies accounts);
        void UpdateCurrencyRecord(Currencies accounts);
        void DeleteCurrencyRecord(int id);

        List<Files> GetFilesRecords();
        Files GetFileRecord(int id);
        void AddFileRecord(Files accounts);
        void UpdateFileRecord(Files accounts);
        void DeleteFileRecord(int id);

        List<Groups> GetGroupsRecords();
        Groups GetGroupRecord(int id);
        void AddGroupRecord(Groups accounts);
        void UpdateGroupRecord(Groups accounts);
        void DeleteGroupRecord(int id);

        List<Locations> GetLocationsRecords();
        Locations GetLocationRecord(int id);
        void AddLocationRecord(Locations accounts);
        void UpdateLocationRecord(Locations accounts);
        void DeleteLocationRecord(int id);

        List<OrderHistory> GetOrderHistoryRecords();
        OrderHistory GetOrderHistoryRecord(int id);
        void AddOrderHistoryRecord(OrderHistory accounts);
        void UpdateOrderHistoryRecord(OrderHistory accounts);
        void DeleteOrderHistoryRecord(int id);

        List<OrderItems> GetOrderItemsRecords();
        OrderItems GetOrderItemRecord(int id);
        void AddOrderItemRecord(OrderItems accounts);
        void UpdateOrderItemRecord(OrderItems accounts);
        void DeleteOrderItemRecord(int id);

        List<Orders> GetOrdersRecords();
        Orders GetOrderRecord(int id);
        void AddOrderRecord(Orders accounts);
        void UpdateOrderRecord(Orders accounts);
        void DeleteOrderRecord(int id);

        List<Organizations> GetOrganizationsRecords();
        Organizations GetOrganizationRecord(int id);
        void AddOrganizationRecord(Organizations accounts);
        void UpdateOrganizationRecord(Organizations accounts);
        void DeleteOrganizationRecord(int id);

        List<PackageItems> GetPackageItemsRecords();
        PackageItems GetPackageItemRecord(int id);
        void AddPackageItemRecord(PackageItems accounts);
        void UpdatePackageItemRecord(PackageItems accounts);
        void DeletePackageItemRecord(int id);

        List<Packages> GetPackagesRecords();
        Packages GetPackageRecord(int id);
        void AddPackageRecord(Packages accounts);
        void UpdatePackageRecord(Packages accounts);
        void DeletePackageRecord(int id);

        List<Products> GetProductsRecords();
        Products GetProductRecord(int id);
        void AddProductRecord(Products accounts);
        void UpdateProductRecord(Products accounts);
        void DeleteProductRecord(int id);

        List<Roles> GetRolesRecords();
        Roles GetRoleRecord(int id);
        void AddRoleRecord(Roles accounts);
        void UpdateRoleRecord(Roles accounts);
        void DeleteRoleRecord(int id);

        List<Tasks> GetTasksRecords();
        Tasks GetTaskRecord(int id);
        void AddTaskRecord(Tasks accounts);
        void UpdateTaskRecord(Tasks accounts);
        void DeleteTaskRecord(int id);

        List<Types> GetTypesRecords();
        Types GetTypeRecord(int id);
        void AddTypeRecord(Types accounts);
        void UpdateTypeRecord(Types accounts);
        void DeleteTypeRecord(int id);

        List<Users> GetUsersRecords();
        Users GetUserRecord(int id);
        void AddUserRecord(Users accounts);
        void UpdateUserRecord(Users accounts);
        void DeleteUserRecord(int id);

        List<Vehicles> GetVehiclesRecords();
        Vehicles GetVehicleRecord(int id);
        void AddVehicleRecord(Vehicles accounts);
        void UpdateVehicleRecord(Vehicles accounts);
        void DeleteVehicleRecord(int id);

        List<VehicleModels> GetVehicleModelsRecords();
        VehicleModels GetVehicleModelRecord(int id);
        void AddVehicleModelRecord(VehicleModels accounts);
        void UpdateVehicleModelRecord(VehicleModels accounts);
        void DeleteVehicleModelRecord(int id);

        List<VehiclesEquipments> GetVehiclesEquipmentsRecords();
        VehiclesEquipments GetVehicleEquipmentRecord(int id);
        void AddVehicleEquipmentRecord(VehiclesEquipments accounts);
        void UpdateVehicleEquipmentRecord(VehiclesEquipments accounts);
        void DeleteVehicleEquipmentRecord(int id);
    }
}
