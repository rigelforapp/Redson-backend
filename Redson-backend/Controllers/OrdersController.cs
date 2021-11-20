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
            return _dataAccessProvider.GetOrderRecords();
        }

        [HttpGet("{Id}")]
        public Order Details(int Id)
        {
            return _dataAccessProvider.GetOrderRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            return CreateEntity(order);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Order order)
        {
            return UpdateEntity(order);
        }

    }
}
