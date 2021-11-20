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
            return _dataAccessProvider.GetPackageRecords();
        }

        [HttpGet("{Id}")]
        public Package Details(int Id)
        {
            return _dataAccessProvider.GetPackageRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Package package)
        {
            return CreateEntity(package);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Package package)
        {
            return UpdateEntity(package);
        }

    }
}
