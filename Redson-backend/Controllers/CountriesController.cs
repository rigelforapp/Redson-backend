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

    public class CountriesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public CountriesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Countries> Get()
        {
            return _dataAccessProvider.GetCountriesRecords();
        }

        [HttpGet("{id}")]
        public Countries Details(int id)
        {
            return _dataAccessProvider.GetCountryRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Countries country)
        {
            if (ModelState.IsValid)
            {
                country.updated_at = DateTime.Now;
                _dataAccessProvider.AddCountryRecord(country);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Countries country)
        {
            if (ModelState.IsValid)
            {
                country.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateCountryRecord(country);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var country = _dataAccessProvider.GetCountryRecord(id);
            if (country == null)
            {
                return NotFound();
            }
            else {
                country.updated_at = DateTime.Now;
                country.is_deleted = true;
                _dataAccessProvider.UpdateCountryRecord( country );
            }
            return Ok();
        }

    }
}
