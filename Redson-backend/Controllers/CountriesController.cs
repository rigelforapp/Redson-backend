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

    public class CountriesController : GenericC
    {

        public CountriesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Country";
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _dataAccessProvider.GetCountryRecords();
        }

        [HttpGet("{Id}")]
        public Country Details(int Id)
        {
            return _dataAccessProvider.GetCountryRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Country countries)
        {
            return CreateEntity(countries);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Country countries)
        {
            return UpdateEntity(countries);
        }

    }
}
