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

    public class CurrenciesController : GenericC
    {

        public CurrenciesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Currency";
        }

        [HttpGet]
        public IEnumerable<Currency> Get()
        {
            return (List<Currency>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Currency Details(int id)
        {
            return (Currency)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Currency entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Currency entity)
        {
            return UpdateEntity(entity);
        }

    }
}
