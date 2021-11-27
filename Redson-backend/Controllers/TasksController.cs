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

    public class TasksController : GenericC
    {

        public TasksController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Task";
        }

        [HttpGet]
        public IEnumerable<Models.Task> Get()
        {
            return (List<Models.Task>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Models.Task Details(int id)
        {
            return (Models.Task)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Models.Task entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Models.Task entity)
        {
            return UpdateEntity(entity);
        }

    }
}
