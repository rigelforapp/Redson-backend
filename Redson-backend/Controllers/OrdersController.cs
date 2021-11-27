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

    public class OrdersController : GenericC
    {

        public OrdersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Order";
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return (List<Order>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Order Details(int id)
        {
            return (Order)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Order entity)
        {
            return UpdateEntity(entity);
        }

    }
}
