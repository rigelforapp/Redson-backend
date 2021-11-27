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
            return (List<Group>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Group Details(int id)
        {
            return (Group)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Group entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Group entity)
        {
            return UpdateEntity(entity);
        }

    }
}
