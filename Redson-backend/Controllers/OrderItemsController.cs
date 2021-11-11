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

    public class OrderItemsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public OrderItemsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<OrderItems> Get()
        {
            return _dataAccessProvider.GetOrderItemsRecords();
        }

        [HttpGet("{id}")]
        public OrderItems Details(int id)
        {
            return _dataAccessProvider.GetOrderItemRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderItems orderItem)
        {
            if (ModelState.IsValid)
            {
                orderItem.updated_at = DateTime.Now;
                _dataAccessProvider.AddOrderItemRecord(orderItem);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] OrderItems orderItem)
        {
            if (ModelState.IsValid)
            {
                orderItem.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateOrderItemRecord(orderItem);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderItem = _dataAccessProvider.GetOrderItemRecord(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            else
            {
                orderItem.updated_at = DateTime.Now;
                orderItem.is_deleted = true;
                _dataAccessProvider.UpdateOrderItemRecord(orderItem);
            }
            return Ok();
        }

    }
}
