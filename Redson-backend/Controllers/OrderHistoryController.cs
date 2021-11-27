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
            return (List<OrderHistory>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public OrderHistory Details(int id)
        {
            return (OrderHistory)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderHistory entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] OrderHistory entity)
        {
            return UpdateEntity(entity);
        }

    }
}
