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

    public class OrganizationsController : GenericC
    {

        public OrganizationsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Organization";
        }

        [HttpGet]
        public IEnumerable<Organization> Get()
        {
            return (List<Organization>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Organization Details(int id)
        {
            return (Organization)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Organization entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Organization entity)
        {
            return UpdateEntity(entity);
        }

    }
}
