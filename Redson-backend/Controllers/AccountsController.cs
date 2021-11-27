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
            return (List<Account>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Account Details(int id)
        {
            return (Account)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Account entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Account entity)
        {
            return UpdateEntity(entity);
        }

    }
}
