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

    public class VehicleModelsController : GenericC
    {

        public VehicleModelsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "VehicleModel";
        }

        [HttpGet]
        public IEnumerable<VehicleModel> Get()
        {
            return (List<VehicleModel>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public VehicleModel Details(int id)
        {
            return (VehicleModel)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] VehicleModel entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] VehicleModel entity)
        {
            return UpdateEntity(entity);
        }

    }
}
