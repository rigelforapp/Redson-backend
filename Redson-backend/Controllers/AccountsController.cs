﻿using Microsoft.AspNetCore.Mvc;
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
            return _dataAccessProvider.GetAccountRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Accounts account)
        {
            if (ModelState.IsValid)
            {
                account.updated_at = DateTime.Now;
                _dataAccessProvider.AddAccountRecord(account);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Accounts account)
        {
            if (ModelState.IsValid)
            {
                account.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateAccountRecord(account);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var account = _dataAccessProvider.GetAccountRecord(id);
            if (account == null)
            {
                return NotFound();
            }
            else
            {
                account.updated_at = DateTime.Now;
                account.is_deleted = true;
                _dataAccessProvider.UpdateAccountRecord(account);
            }
            return Ok();
        }

    }
}
