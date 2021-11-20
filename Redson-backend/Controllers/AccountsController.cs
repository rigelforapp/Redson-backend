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

    public class AccountsController : GenericC
    {

        public AccountsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType     = "Account";
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            var data = _dataAccessProvider.GetAccountRecords();
            return _dataAccessProvider.GetAccountRecords();
        }

        [HttpGet("{Id}")]
        public Account Details(int Id)
        {
            return _dataAccessProvider.GetAccountRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Account account)
        {
            return CreateEntity(account);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Account account)
        {
            return UpdateEntity(account);
        }

    }
}
