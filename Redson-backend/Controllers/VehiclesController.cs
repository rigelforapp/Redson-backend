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

    public class VehiclesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public VehiclesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Vehicles> Get()
        {
            return _dataAccessProvider.GetVehiclesRecords();
        }

        [HttpGet("{id}")]
        public Vehicles Details(int id)
        {
            return _dataAccessProvider.GetVehicleRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vehicles vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.updated_at = DateTime.Now;
                _dataAccessProvider.AddVehicleRecord(vehicle);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Vehicles vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateVehicleRecord(vehicle);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehicle = _dataAccessProvider.GetVehicleRecord(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                vehicle.updated_at = DateTime.Now;
                vehicle.is_deleted = true;
                _dataAccessProvider.UpdateVehicleRecord(vehicle);
            }
            return Ok();
        }

    }
}
