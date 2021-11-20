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
            return _dataAccessProvider.GetPackageItemRecords();
        }

        [HttpGet("{Id}")]
        public PackageItem Details(int Id)
        {
            return _dataAccessProvider.GetPackageItemRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PackageItem packageItem)
        {
            return CreateEntity(packageItem);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] PackageItem packageItem)
        {
            return UpdateEntity(packageItem);
        }

    }
}
