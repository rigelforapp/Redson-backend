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

    public class TasksController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public TasksController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Tasks> Get()
        {
            return _dataAccessProvider.GetTasksRecords();
        }

        [HttpGet("{id}")]
        public Tasks Details(int id)
        {
            return _dataAccessProvider.GetTaskRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tasks task)
        {
            if (ModelState.IsValid)
            {
                task.updated_at = DateTime.Now;
                _dataAccessProvider.AddTaskRecord(task);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Tasks task)
        {
            if (ModelState.IsValid)
            {
                task.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateTaskRecord(task);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _dataAccessProvider.GetTaskRecord(id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                task.updated_at = DateTime.Now;
                task.is_deleted = true;
                _dataAccessProvider.UpdateTaskRecord(task);
            }
            return Ok();
        }

    }
}
