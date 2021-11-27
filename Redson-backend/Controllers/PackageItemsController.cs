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

    public class PackageItemsController : GenericC
    {

        public PackageItemsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "PackageItem";
        }

        [HttpGet]
        public IEnumerable<PackageItem> Get()
        {
            return (List<PackageItem>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public PackageItem Details(int id)
        {
            return (PackageItem)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PackageItem entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] PackageItem entity)
        {
            return UpdateEntity(entity);
        }

    }
}
