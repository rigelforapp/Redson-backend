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

    public class ManufacturerController : GenericC
    {

        public ManufacturerController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Manufacturer";
        }

        [HttpGet]
        public IEnumerable<Manufacturer> Get()
        {
            return (List<Manufacturer>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Manufacturer Details(int id)
        {
            return (Manufacturer)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Manufacturer entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Manufacturer entity)
        {
            return UpdateEntity(entity);
        }

    }
}
