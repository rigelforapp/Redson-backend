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

    public class RolesController : GenericC
    {

        public RolesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Role";
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return (List<Role>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Role Details(int id)
        {
            return (Role)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Role entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Role entity)
        {
            return UpdateEntity(entity);
        }

    }
}
