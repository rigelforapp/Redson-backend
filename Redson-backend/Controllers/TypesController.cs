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

    public class TypesController : GenericC
    {

        public TypesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Type";
        }

        [HttpGet]
        public IEnumerable<Models.Type> Get()
        {
            return (List<Models.Type>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Models.Type Details(int id)
        {
            return (Models.Type)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Models.Type entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Models.Type entity)
        {
            return UpdateEntity(entity);
        }

    }
}
