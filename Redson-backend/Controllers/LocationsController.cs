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

    public class LocationsController : GenericC
    {

        public LocationsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Location";
        }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return _dataAccessProvider.GetLocationRecords();
        }

        [HttpGet("{Id}")]
        public Location Details(int Id)
        {
            return _dataAccessProvider.GetLocationRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Location location)
        {
            return CreateEntity(location);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Location location)
        {
            return UpdateEntity(location);
        }

    }
}
