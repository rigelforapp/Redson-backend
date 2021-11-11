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

    public class OrganizationsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public OrganizationsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Organizations> Get()
        {
            return _dataAccessProvider.GetOrganizationsRecords();
        }

        [HttpGet("{id}")]
        public Organizations Details(int id)
        {
            return _dataAccessProvider.GetOrganizationRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Organizations organization)
        {
            if (ModelState.IsValid)
            {
                organization.updated_at = DateTime.Now;
                _dataAccessProvider.AddOrganizationRecord(organization);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Organizations organization)
        {
            if (ModelState.IsValid)
            {
                organization.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateOrganizationRecord(organization);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var organization = _dataAccessProvider.GetOrganizationRecord(id);
            if (organization == null)
            {
                return NotFound();
            }
            else
            {
                organization.updated_at = DateTime.Now;
                organization.is_deleted = true;
                _dataAccessProvider.UpdateOrganizationRecord(organization);
            }
            return Ok();
        }

    }
}
