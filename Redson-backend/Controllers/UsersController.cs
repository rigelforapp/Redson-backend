using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.DataAccess;
using Redson_backend.Models;
using Redson_backend.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace Redson_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : GenericC
    {

        public UsersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "User";
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return (List<User>)GetAllEntities();
        }

        protected override Object afterGetAll(Object entityList)
        {
            var userList = (List<User>)entityList;
            foreach (var entity in userList)
            {
                var user = entity;
                user.Password = "";
            }

            return userList;
        }

        [HttpGet("{id}")]
        public User Details(int id)
        {
            return (User)GetEntity(id);
        }

        protected override EntityBaseNoId afterGet(EntityBaseNoId entity)
        {
            var user = (User)entity;
            user.Password = "";
            return user;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User entity)
        {
            return CreateEntity(entity);
        }

        protected override EntityBaseNoId beforeCreate(EntityBaseNoId entity)
        {
            var user = (User)entity;

            byte[] encData_byte = new byte[user.Password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(user.Password);
            string encodedData = Convert.ToBase64String(encData_byte);

            user.Password = encodedData;

            return user;
        }

        protected override EntityBaseNoId afterCreate(EntityBaseNoId entity)
        {
            var user = (User)entity;
            user.Password = "";
            return user;
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User entity)
        {
            return UpdateEntity(entity);
        }

        protected override EntityBaseNoId beforeUpdate(EntityBaseNoId entity)
        {
            var user = (User)entity;

            byte[] encData_byte = new byte[user.Password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(user.Password);
            string encodedData = Convert.ToBase64String(encData_byte);

            user.Password = encodedData;

            return user;
        }

        protected override EntityBaseNoId afterUpdate(EntityBaseNoId entity)
        {
            var user = (User)entity;
            user.Password = "";
            return user;
        }

    }
}
