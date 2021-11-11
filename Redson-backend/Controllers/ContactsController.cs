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

    public class ContactsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public ContactsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Contacts> Get()
        {
            return _dataAccessProvider.GetContactsRecords();
        }

        [HttpGet("{id}")]
        public Contacts Details(int id)
        {
            return _dataAccessProvider.GetContactRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contacts contact)
        {
            if (ModelState.IsValid)
            {
                contact.updated_at = DateTime.Now;
                _dataAccessProvider.AddContactRecord(contact);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Contacts contact)
        {
            if (ModelState.IsValid)
            {
                contact.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateContactRecord(contact);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = _dataAccessProvider.GetContactRecord(id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                contact.updated_at = DateTime.Now;
                contact.is_deleted = true;
                _dataAccessProvider.UpdateContactRecord(contact);
            }
            return Ok();
        }

    }
}
