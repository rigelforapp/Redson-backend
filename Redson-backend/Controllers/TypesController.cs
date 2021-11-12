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

    public class TypesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public TypesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Types> Get()
        {
            return _dataAccessProvider.GetTypesRecords();
        }

        [HttpGet("{id}")]
        public Types Details(int id)
        {
            return _dataAccessProvider.GetTypeRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Types type)
        {
            if (ModelState.IsValid)
            {
                type.updated_at = DateTime.Now;
                _dataAccessProvider.AddTypeRecord(type);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Types type)
        {
            if (ModelState.IsValid)
            {
                type.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateTypeRecord(type);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var type = _dataAccessProvider.GetTypeRecord(id);
            if (type == null)
            {
                return NotFound();
            }
            else
            {
                type.updated_at = DateTime.Now;
                type.is_deleted = true;
                _dataAccessProvider.UpdateTypeRecord(type);
            }
            return Ok();
        }

    }
}
