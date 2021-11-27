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

    public class VehiclesController : GenericC
    {

        public VehiclesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Vehicle";
        }

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return (List<Vehicle>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Vehicle Details(int id)
        {
            return (Vehicle)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vehicle entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Vehicle entity)
        {
            return UpdateEntity(entity);
        }

    }
}
