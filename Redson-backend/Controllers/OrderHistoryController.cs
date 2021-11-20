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

    public class OrderHistoryController : GenericC
    {

        public OrderHistoryController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "OrderHistory";
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
            return CreateEntity(orderHistory);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] OrderHistory orderHistory)
        {
            return UpdateEntity(orderHistory);
        }

    }
}
