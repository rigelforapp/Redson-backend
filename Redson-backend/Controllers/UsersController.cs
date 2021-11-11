using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.DataAccess;
using Redson_backend.Models;

namespace Redson_backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public UsersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _dataAccessProvider.GetUsersRecords();
        }

        [HttpGet("{id}")]
        public Users Details(int id)
        {
            return _dataAccessProvider.GetUserRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Users user)
        {
            if (ModelState.IsValid)
            {
                user.updated_at = DateTime.Now;
                _dataAccessProvider.AddUserRecord(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Users user)
        {
            if (ModelState.IsValid)
            {
                user.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateUserRecord(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _dataAccessProvider.GetUserRecord(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.updated_at = DateTime.Now;
                user.is_deleted = true;
                _dataAccessProvider.UpdateUserRecord(user);
            }
            return Ok();
        }

    }
}
