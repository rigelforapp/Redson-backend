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

    public class LocationsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public LocationsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Locations> Get()
        {
            return _dataAccessProvider.GetLocationsRecords();
        }

        [HttpGet("{id}")]
        public Locations Details(int id)
        {
            return _dataAccessProvider.GetLocationRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Locations location)
        {
            if (ModelState.IsValid)
            {
                location.updated_at = DateTime.Now;
                _dataAccessProvider.AddLocationRecord(location);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Locations location)
        {
            if (ModelState.IsValid)
            {
                location.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateLocationRecord(location);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var location = _dataAccessProvider.GetLocationRecord(id);
            if (location == null)
            {
                return NotFound();
            }
            else
            {
                location.updated_at = DateTime.Now;
                location.is_deleted = true;
                _dataAccessProvider.UpdateLocationRecord(location);
            }
            return Ok();
        }

    }
}
