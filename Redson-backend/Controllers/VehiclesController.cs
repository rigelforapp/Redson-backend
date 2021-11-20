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
            return _dataAccessProvider.GetVehicleRecords();
        }

        [HttpGet("{Id}")]
        public Vehicle Details(int Id)
        {
            return _dataAccessProvider.GetVehicleRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vehicle vehicle)
        {
            return CreateEntity(vehicle);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Vehicle vehicle)
        {
            return UpdateEntity(vehicle);
        }

    }
}
