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
        public IActionResult deleteEntity(int id, IDataAccessProvider _dataAccessProvider)
        {
            //var entity = _dataAccessProvider.GetCountryRecord(id);
            var entity = this.getEntity(id, _dataAccessProvider);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.updated_at = DateTime.Now;
                entity.is_deleted = true;
                //_dataAccessProvider.UpdateCountryRecord(entity);
            }
            return Ok();
        }

        public Base getEntity(int id, IDataAccessProvider _dataAccessProvider) {
            switch (this.entityType)
            {
                case "country":
                    return _dataAccessProvider.GetCountryRecord(id);
                default:
                    break;
            }
            return null;
        }

        public Base updateEntity(Base entity, IDataAccessProvider _dataAccessProvider)
        {
            switch (this.entityType)
            {
                case "country":
                    //return _dataAccessProvider.UpdateCountryRecord(entity);
                default:
                    break;
            }
            return null;
        }
    }
}
