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

    public class ContactsController : GenericC
    {

        public ContactsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Contact";
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _dataAccessProvider.GetContactRecords();
        }

        [HttpGet("{Id}")]
        public Contact Details(int Id)
        {
            return _dataAccessProvider.GetContactRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact contact)
        {
            return CreateEntity(contact);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Contact contact)
        {
            return UpdateEntity(contact);
        }

    }
}
