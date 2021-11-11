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

    public class CurrenciesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public CurrenciesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Currencies> Get()
        {
            return _dataAccessProvider.GetCurrenciesRecords();
        }

        [HttpGet("{id}")]
        public Currencies Details(int id)
        {
            return _dataAccessProvider.GetCurrencyRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Currencies currency)
        {
            if (ModelState.IsValid)
            {
                currency.updated_at = DateTime.Now;
                _dataAccessProvider.AddCurrencyRecord(currency);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Currencies currency)
        {
            if (ModelState.IsValid)
            {
                currency.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateCurrencyRecord(currency);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var currency = _dataAccessProvider.GetCurrencyRecord(id);
            if (currency == null)
            {
                return NotFound();
            }
            else
            {
                currency.updated_at = DateTime.Now;
                currency.is_deleted = true;
                _dataAccessProvider.UpdateCurrencyRecord(currency);
            }
            return Ok();
        }

    }
}
