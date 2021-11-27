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

    public class PackagesController : GenericC
    {

        public PackagesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Package";
        }

        [HttpGet]
        public IEnumerable<Package> Get()
        {
            return (List<Package>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Package Details(int id)
        {
            return (Package)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Package entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Package entity)
        {
            return UpdateEntity(entity);
        }

    }
}
