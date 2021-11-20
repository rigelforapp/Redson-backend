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
    [Authorize]
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
            return _dataAccessProvider.GetUserRecords();
        }

        [HttpGet("{Id}")]
        public User Details(int Id)
        {
            return _dataAccessProvider.GetUserRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            return CreateEntity(user);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User user)
        {
            return UpdateEntity(user);
        }

    }
}
