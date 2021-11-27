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
            return (List<Contact>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Contact Details(int id)
        {
            return (Contact)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Contact entity)
        {
            return UpdateEntity(entity);
        }

    }
}
