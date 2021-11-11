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

    public class PackageItemsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public PackageItemsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<PackageItems> Get()
        {
            return _dataAccessProvider.GetPackageItemsRecords();
        }

        [HttpGet("{id}")]
        public PackageItems Details(int id)
        {
            return _dataAccessProvider.GetPackageItemRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PackageItems packageItems)
        {
            if (ModelState.IsValid)
            {
                packageItems.updated_at = DateTime.Now;
                _dataAccessProvider.AddPackageItemRecord(packageItems);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] PackageItems packageItems)
        {
            if (ModelState.IsValid)
            {
                packageItems.updated_at = DateTime.Now;
                _dataAccessProvider.UpdatePackageItemRecord(packageItems);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var packageItems = _dataAccessProvider.GetPackageItemRecord(id);
            if (packageItems == null)
            {
                return NotFound();
            }
            else
            {
                packageItems.updated_at = DateTime.Now;
                packageItems.is_deleted = true;
                _dataAccessProvider.UpdatePackageItemRecord(packageItems);
            }
            return Ok();
        }

    }
}
