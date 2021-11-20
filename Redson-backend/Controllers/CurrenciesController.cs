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
            return _dataAccessProvider.GetCurrencyRecords();
        }

        [HttpGet("{Id}")]
        public Currency Details(int Id)
        {
            return _dataAccessProvider.GetCurrencyRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Currency currency)
        {
            return CreateEntity(currency);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Currency currency)
        {
            return UpdateEntity(currency);
        }

    }
}
