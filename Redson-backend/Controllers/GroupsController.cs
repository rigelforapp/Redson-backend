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

    public class GroupsController : GenericC
    {

        public GroupsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Group";
        }

        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return _dataAccessProvider.GetGroupRecords();
        }

        [HttpGet("{Id}")]
        public Group Details(int Id)
        {
            return _dataAccessProvider.GetGroupRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Group group)
        {
            return CreateEntity(group);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Group group)
        {
            return UpdateEntity(group);
        }

    }
}
