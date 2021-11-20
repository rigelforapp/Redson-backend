using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.DataAccess;
using Redson_backend.Models;
using System.Reflection;

namespace Redson_backend.Controllers
{

    public class GenericC : ControllerBase
    {
        public string entityType = "";

        public IDataAccessProvider _dataAccessProvider;

        /*[HttpGet]
        public IEnumerable<Accounts> Get()
        {
            return _dataAccessProvider.GetAccountsRecords();
        }

        [HttpGet("{id}")]
        public Base Details(int id)
        {
            Type dataAccessProviderType = _dataAccessProvider.GetType();
            MethodInfo GetRecordMethod = dataAccessProviderType.GetMethod("Get" + this.entityType + "Record");

            var obj = GetRecordMethod.Invoke(_dataAccessProvider, new object[] { id });

            return CastType(obj);
        }*/

        protected IActionResult CreateEntity(Base baseObj)
        {
            if (
                ModelState.IsValid &&
                ValidateBaseParameters(baseObj)
            )
            {
                baseObj.created_at = DateTime.Now;
                baseObj.updated_at = DateTime.Now;

                Type dataAccessProviderType = _dataAccessProvider.GetType();
                MethodInfo AddRecordMethod = dataAccessProviderType.GetMethod("Update" + this.entityType + "Record");

                AddRecordMethod.Invoke(_dataAccessProvider, new object[] { baseObj });
                return Ok(baseObj);
            }
            return BadRequest();
        }

        protected IActionResult UpdateEntity(Base baseObj)
        {
            if (
                ModelState.IsValid &&
                ValidateBaseParameters(baseObj) &&
                baseObj.id != null
            )
            {
                baseObj.updated_at = DateTime.Now;

                Type dataAccessProviderType = _dataAccessProvider.GetType();
                MethodInfo updateRecordMethod = dataAccessProviderType.GetMethod("Update" + this.entityType + "Record");
                MethodInfo getRecordMethod = dataAccessProviderType.GetMethod("Get" + this.entityType + "Record");

                object lastBaseObj = getRecordMethod.Invoke(_dataAccessProvider, new object[] { baseObj.id });
                var lastBaseObjCasted = CastType(lastBaseObj);

                lastBaseObjCasted = CopyValues(lastBaseObjCasted, baseObj);
                //lastBaseObjCasted = baseObj;

                
                updateRecordMethod.Invoke(_dataAccessProvider, new object[] { lastBaseObjCasted });

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id, [FromHeader(Name = "Authorization")] string auth)
        {
            var headers = Request.Headers;
            Console.WriteLine(auth);
            Type dataAccessProviderType = _dataAccessProvider.GetType();
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
                objCasted.updated_at = DateTime.Now;
                objCasted.is_deleted = true;

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
                    return (Accounts)obj;
            }

            return null;
        }

        protected bool ValidateBaseParameters(Base entity)
        {
            if (
                entity.created_at != null ||
                entity.updated_at != null ||
                entity.created_by_id != null ||
                entity.updated_by_id != null ||
                entity.is_active != null ||
                entity.is_deleted != null)
            {
                return false;
            }
            return true;
        }

        protected T CopyValues<T>(T target, T source)
        {
            Type t = typeof(Base);
            switch (entityType)
            {
                case "Account":
                    t = typeof(Accounts);
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
        
    }
}
