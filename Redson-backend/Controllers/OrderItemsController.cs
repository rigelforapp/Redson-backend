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

    public class OrderItemsController : GenericC
    {

        public OrderItemsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "OrderItem";
        }

        [HttpGet]
        public IEnumerable<OrderItem> Get()
        {
            return (List<OrderItem>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public OrderItem Details(int id)
        {
            return (OrderItem)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderItem entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] OrderItem entity)
        {
            return UpdateEntity(entity);
        }

    }
}
