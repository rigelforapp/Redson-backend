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

    public class OrdersController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public OrdersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            return _dataAccessProvider.GetOrdersRecords();
        }

        [HttpGet("{id}")]
        public Orders Details(int id)
        {
            return _dataAccessProvider.GetOrderRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Orders order)
        {
            if (ModelState.IsValid)
            {
                order.updated_at = DateTime.Now;
                _dataAccessProvider.AddOrderRecord(order);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Orders order)
        {
            if (ModelState.IsValid)
            {
                order.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateOrderRecord(order);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _dataAccessProvider.GetOrderRecord(id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                order.updated_at = DateTime.Now;
                order.is_deleted = true;
                _dataAccessProvider.UpdateOrderRecord(order);
            }
            return Ok();
        }

    }
}
