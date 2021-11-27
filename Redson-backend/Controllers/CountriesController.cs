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
            return (List<Country>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Country Details(int id)
        {
            return (Country)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Country entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Country entity)
        {
            return UpdateEntity(entity);
        }

    }
}
