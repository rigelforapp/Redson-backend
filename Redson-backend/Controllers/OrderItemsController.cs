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
            return _dataAccessProvider.GetOrderItemRecords();
        }

        [HttpGet("{Id}")]
        public OrderItem Details(int Id)
        {
            return _dataAccessProvider.GetOrderItemRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderItem orderItem)
        {
            return CreateEntity(orderItem);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] OrderItem orderItem)
        {
            return UpdateEntity(orderItem);
        }

    }
}
