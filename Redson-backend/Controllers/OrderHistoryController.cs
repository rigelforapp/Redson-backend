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

    public class OrderHistoryController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public OrderHistoryController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<OrderHistory> Get()
        {
            return _dataAccessProvider.GetOrderHistoryRecords();
        }

        [HttpGet("{id}")]
        public OrderHistory Details(int id)
        {
            return _dataAccessProvider.GetOrderHistoryRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                orderHistory.updated_at = DateTime.Now;
                _dataAccessProvider.AddOrderHistoryRecord(orderHistory);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] OrderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                orderHistory.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateOrderHistoryRecord(orderHistory);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderHistory = _dataAccessProvider.GetOrderHistoryRecord(id);
            if (orderHistory == null)
            {
                return NotFound();
            }
            else
            {
                orderHistory.updated_at = DateTime.Now;
                orderHistory.is_deleted = true;
                _dataAccessProvider.UpdateOrderHistoryRecord(orderHistory);
            }
            return Ok();
        }

    }
}
