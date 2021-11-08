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

    public class AccountsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public AccountsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Accounts> Get()
        {
            return _dataAccessProvider.GetAccountsRecords();
        }

        [HttpGet("{id}")]
        public Accounts Details(int id)
        {
            return _dataAccessProvider.GetAccountsSingleRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddAccountsRecord(accounts);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateAccountRecord(accounts);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetAccountsSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteAccountRecord(id);
            return Ok();
        }



    }
}
