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

    public class TypesController : GenericC
    {

        public TypesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Type";
        }

        [HttpGet]
        public IEnumerable<Redson_backend.Models.Type> Get()
        {
            return _dataAccessProvider.GetTypeRecords();
        }

        [HttpGet("{Id}")]
        public Redson_backend.Models.Type Details(int Id)
        {
            return _dataAccessProvider.GetTypeRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Redson_backend.Models.Type type)
        {
            return CreateEntity(type);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Redson_backend.Models.Type type)
        {
            return UpdateEntity(type);
        }

    }
}
