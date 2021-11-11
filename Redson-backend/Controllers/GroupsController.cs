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

    public class GroupsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public GroupsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Groups> Get()
        {
            return _dataAccessProvider.GetGroupsRecords();
        }

        [HttpGet("{id}")]
        public Groups Details(int id)
        {
            return _dataAccessProvider.GetGroupRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Groups group)
        {
            if (ModelState.IsValid)
            {
                group.updated_at = DateTime.Now;
                _dataAccessProvider.AddGroupRecord(group);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Groups group)
        {
            if (ModelState.IsValid)
            {
                group.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateGroupRecord(group);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var group = _dataAccessProvider.GetGroupRecord(id);
            if (group == null)
            {
                return NotFound();
            }
            else
            {
                group.updated_at = DateTime.Now;
                group.is_deleted = true;
                _dataAccessProvider.UpdateGroupRecord(group);
            }
            return Ok();
        }

    }
}
