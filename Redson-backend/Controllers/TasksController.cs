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

    public class TasksController : GenericC
    {

        public TasksController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Task";
        }

        [HttpGet]
        public IEnumerable<Redson_backend.Models.Task> Get()
        {
            return _dataAccessProvider.GetTaskRecords();
        }

        [HttpGet("{Id}")]
        public Redson_backend.Models.Task Details(int id)
        {
            return _dataAccessProvider.GetTaskRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Redson_backend.Models.Task task)
        {
            return CreateEntity(task);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Redson_backend.Models.Task task)
        {
            return UpdateEntity(task);
        }

    }
}
