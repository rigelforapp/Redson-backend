using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.DataAccess;
using Redson_backend.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace Redson_backend.Controllers
{

    public class GenericC : ControllerBase
    {
        public string entityType = "";

        public IDataAccessProvider _dataAccessProvider;

        protected Object GetAllEntities()
        {
            User logedUser = GetUserByToken();

            if (logedUser == null)
            {
                return null;
            }

            var context = _dataAccessProvider.GetContext();

            System.Type dataAccessProviderType = _dataAccessProvider.GetType();
            MethodInfo GetRecordsMethod = dataAccessProviderType.GetMethod("Get" + this.entityType + "Records");

            DataAccessProvidesParameters dapp = GetParameters(logedUser);
            return GetRecordsMethod.Invoke(_dataAccessProvider, new object[] { dapp });
        }

        protected Base GetEntity(int id)
        {
            User logedUser = GetUserByToken();

            if (logedUser == null)
            {
                return null;
            }

            var context = _dataAccessProvider.GetContext();

            System.Type dataAccessProviderType = _dataAccessProvider.GetType();
            MethodInfo getRecordsMethod = dataAccessProviderType.GetMethod("Get" + this.entityType + "Record");

            var entity = getRecordsMethod.Invoke(_dataAccessProvider, new object[] { id });

            return (Base)entity;
        }

        protected IActionResult CreateEntity(Base baseObj)
        {
            User logedUser = GetUserByToken();

            if (logedUser == null)
            {
                return null;
            }

            if (
                ModelState.IsValid &&
                ValidateBaseParameters(baseObj)
            )
            {
                baseObj.IsActive = true;
                baseObj.IsDeleted = false;
                baseObj.CreatedAt = DateTime.Now;
                baseObj.UpdatedAt = DateTime.Now;
                baseObj.CreatedById = logedUser.Id;
                baseObj.UpdatedById = logedUser.Id;

                System.Type dataAccessProviderType = _dataAccessProvider.GetType();
                MethodInfo createRecordMethod = dataAccessProviderType.GetMethod("Add" + this.entityType + "Record");

                createRecordMethod.Invoke(_dataAccessProvider, new object[] { baseObj });
                return Ok(baseObj);
            }
            return BadRequest();
        }

        protected IActionResult UpdateEntity(Base baseObj)
        {
            User logedUser = GetUserByToken();

            if (logedUser == null)
            {
                return null;
            }

            if (
                ModelState.IsValid &&
                ValidateBaseParameters(baseObj)
            )
            {
                baseObj.UpdatedAt = DateTime.Now;
                baseObj.UpdatedById= logedUser.Id;

                System.Type dataAccessProviderType = _dataAccessProvider.GetType();
                MethodInfo updateRecordMethod = dataAccessProviderType.GetMethod("Update" + this.entityType + "Record");
                MethodInfo getRecordMethod = dataAccessProviderType.GetMethod("Get" + this.entityType + "Record");

                object lastBaseObj = getRecordMethod.Invoke(_dataAccessProvider, new object[] { baseObj.Id });
                var lastBaseObjCasted = CastType(lastBaseObj);

                lastBaseObjCasted = CopyValues(lastBaseObjCasted, baseObj);
                //lastBaseObjCasted = baseObj;

                
                updateRecordMethod.Invoke(_dataAccessProvider, new object[] { lastBaseObjCasted });

                return Ok();
            }
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteLogicalEntity(int id)
        {
            User logedUser = GetUserByToken();

            if (logedUser == null)
            {
                return null;
            }

            System.Type dataAccessProviderType = _dataAccessProvider.GetType();
            MethodInfo getRecordMethod = dataAccessProviderType.GetMethod("Get" + this.entityType + "Record");
            object obj = getRecordMethod.Invoke(_dataAccessProvider, new object[] { id });

            var objCasted = this.CastType(obj);

            //var account = _dataAccessProvider.GetAccountRecord(id);
            if (objCasted == null)
            {
                return NotFound();
            }
            else
            {
                objCasted.UpdatedAt = DateTime.Now;
                objCasted.IsDeleted = true;
                objCasted.UpdatedById = logedUser.Id;

                MethodInfo updateRecordMethod = dataAccessProviderType.GetMethod("Update" + this.entityType + "Record");
                updateRecordMethod.Invoke(_dataAccessProvider, new object[] { objCasted });
            }
            return Ok();
        }
        
        private Base CastType(object obj)
        {
            switch (this.entityType)
            {
                case "Account":
                    return (Account)obj;
                case "Category":
                    return (Category)obj;
                case "Comment":
                    return (Comment)obj;
                case "Contact":
                    return (Contact)obj;
                case "Country":
                    return (Country)obj;
                case "Currency":
                    return (Currency)obj;
                case "File":
                    return (File)obj;
                case "Group":
                    return (Group)obj;
                case "Location":
                    return (Location)obj;
                case "Order":
                    return (Order)obj;
                case "OrderItem":
                    return (OrderItem)obj;
                case "OrderHistory":
                    return (OrderHistory)obj;
                case "Organization":
                    return (Organization)obj;
                case "Package":
                    return (Package)obj;
                case "PackageItem":
                    return (PackageItem)obj;
                case "Product":
                    return (Product)obj;
                case "Role":
                    return (Role)obj;
                case "Task":
                    return (Models.Task)obj;
                case "Type":
                    return (Models.Type)obj;
                case "User":
                    return (User)obj;
                case "Vehicle":
                    return (Vehicle)obj;
                case "VehicleModel":
                    return (VehicleModel)obj;
            }

            return null;
        }

        protected bool ValidateBaseParameters(Base entity)
        {
            if (
                entity.CreatedAt != null ||
                entity.UpdatedAt != null ||
                entity.CreatedById != null ||
                entity.UpdatedById != null ||
                entity.IsActive != null ||
                entity.IsDeleted != null)
            {
                return false;
            }
            return true;
        }

        protected T CopyValues<T>(T target, T source)
        {
            System.Type t = typeof(Base);
            switch (entityType)
            {
                case "Account":
                    t = typeof(Account);
                    break;
                case "Category":
                    t = typeof(Category);
                    break;
                case "Comment":
                    t = typeof(Comment);
                    break;
                case "Contact":
                    t = typeof(Contact);
                    break;
                case "Country":
                    t = typeof(Country);
                    break;
                case "Currency":
                    t = typeof(Currency);
                    break;
                case "File":
                    t = typeof(File);
                    break;
                case "Group":
                    t = typeof(Group);
                    break;
                case "Location":
                    t = typeof(Location);
                    break;
                case "Order":
                    t = typeof(Order);
                    break;
                case "OrderItem":
                    t = typeof(OrderItem);
                    break;
                case "OrderHistory":
                    t = typeof(OrderHistory);
                    break;
                case "Organization":
                    t = typeof(Organization);
                    break;
                case "Package":
                    t = typeof(Package);
                    break;
                case "PackageItem":
                    t = typeof(PackageItem);
                    break;
                case "Product":
                    t = typeof(Product);
                    break;
                case "Role":
                    t = typeof(Role);
                    break;
                case "Task":
                    t = typeof(Models.Task);
                    break;
                case "Type":
                    t = typeof(Models.Type);
                    break;
                case "User":
                    t = typeof(User);
                    break;
                case "Vehicle":
                    t = typeof(Vehicle);
                    break;
                case "VehicleModel":
                    t = typeof(VehicleModel);
                    break;
            }

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var sourceProperty = prop.GetValue(source);

                if (sourceProperty == null)
                {
                    continue;
                }

                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }

            return target;
        }

        protected User GetUserByToken()
        {
            var headers = Request.Headers;
            
            var auth_value = "";

            foreach (var header in headers)
            {
                if (header.Key == "Authorization")
                {
                    auth_value = header.Value;
                    break;
                }
            }

            if (auth_value != "")
            {
                var auth_value_parts = auth_value.Split(" ");
                if (auth_value_parts.Count() == 2)
                {
                    if (auth_value_parts[0] == "bearer")
                    {
                        var token = auth_value_parts[1];
                        var context = _dataAccessProvider.GetContext();
                        User logedUser = context.user.Where(u => u.SessionToken == token).FirstOrDefault();
                        if (logedUser == null)
                        {
                            Response.StatusCode = 401;
                        }
                        return logedUser;
                    }
                }
            }

            Response.StatusCode = 401;
            return null;
            
        }

        protected DataAccessProvidesParameters GetParameters( User logedUser )
        {
            var dapp = new DataAccessProvidesParameters();

            var key = Request.QueryString;
            var value = key.Value;

            if (!string.IsNullOrEmpty(value)) {
                value = value.Substring(1);
                var paramList = value.Split("&");
                foreach (var param in paramList)
                {
                    string paramKey = param.Split('=')[0];
                    string paramValue = param.Split('=')[1];
                    switch (paramKey.ToLower())
                    {
                        case "page":
                            dapp.PageNumber = int.Parse(paramValue);
                            break;
                        case "size":
                            dapp.PageSize = int.Parse(paramValue);
                            break;
                        default:
                            break;
                    }
                }

                if (dapp.PageNumber != 0)
                {
                    dapp.PageSize = int.MaxValue == dapp.PageSize ? 10 : dapp.PageSize;
                    dapp.PageSkip = (dapp.PageNumber - 1) * dapp.PageSize;
                }
            }

            // Account
            var context = _dataAccessProvider.GetContext();
            var uxr = context.userxrole.Where( uxr => uxr.UserId == logedUser.Id && uxr.IsSelected == true ).FirstOrDefault();
            if ( uxr != null )
            {
                dapp.AccountId = uxr.AccountId;
            }

            return dapp;
        }
    }
}
