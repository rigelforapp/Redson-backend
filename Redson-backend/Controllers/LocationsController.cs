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
            return (List<Location>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Location Details(int id)
        {
            return (Location)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Location entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Location entity)
        {
            return UpdateEntity(entity);
        }

    }
}
