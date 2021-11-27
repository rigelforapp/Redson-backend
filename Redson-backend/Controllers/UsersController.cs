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

        [HttpGet("{id}")]
        public User Details(int id)
        {
            return (User)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User entity)
        {
            return UpdateEntity(entity);
        }

    }
}
