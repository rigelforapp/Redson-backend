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

    public class PackagesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public PackagesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Packages> Get()
        {
            return _dataAccessProvider.GetPackagesRecords();
        }

        [HttpGet("{id}")]
        public Packages Details(int id)
        {
            return _dataAccessProvider.GetPackageRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Packages package)
        {
            if (ModelState.IsValid)
            {
                package.updated_at = DateTime.Now;
                _dataAccessProvider.AddPackageRecord(package);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Packages package)
        {
            if (ModelState.IsValid)
            {
                package.updated_at = DateTime.Now;
                _dataAccessProvider.UpdatePackageRecord(package);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var package = _dataAccessProvider.GetPackageRecord(id);
            if (package == null)
            {
                return NotFound();
            }
            else
            {
                package.updated_at = DateTime.Now;
                package.is_deleted = true;
                _dataAccessProvider.UpdatePackageRecord(package);
            }
            return Ok();
        }

    }
}
