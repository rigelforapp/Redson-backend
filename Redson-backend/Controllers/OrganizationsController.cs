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
            return _dataAccessProvider.GetOrganizationRecords();
        }

        [HttpGet("{Id}")]
        public Organization Details(int Id)
        {
            return _dataAccessProvider.GetOrganizationRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Organization organization)
        {
            return CreateEntity(organization);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Organization organization)
        {
            return UpdateEntity(organization);
        }

    }
}
