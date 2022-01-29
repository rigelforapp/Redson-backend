using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.DataAccess;
using Redson_backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace Redson_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersXRolesController : GenericC
    {

        public UsersXRolesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "UsersXRole";
        }

        [HttpGet]
        public IEnumerable<UsersXRole> Get()
        {
            return (List<UsersXRole>)GetAllEntities();
        }

        /*[HttpGet("{id}")]
        public UsersXRole Details(int id)
        {
            return (UsersXRole)GetEntity(id);
            return null;
        }*/

        [HttpPost]
        public IActionResult Create([FromBody] UsersXRole entity)
        {
            return CreateEntity(entity);
        }

        protected override EntityBaseNoId beforeCreate(EntityBaseNoId entity)
        {
            var usersXRole = (UsersXRole)entity;
            var usersXRoles = _dataAccessProvider
                                .GetUsersXRoleRecords(new DataAccessProvidesParameters())
                                .Where(uxr => uxr.UserId == usersXRole.UserId).ToList();

            foreach (var uxr in usersXRoles)
            {
                uxr.IsSelected = false;
            }

            return usersXRole;
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UsersXRole entity)
        {
            return UpdateEntity(entity);
        }

    }
}
