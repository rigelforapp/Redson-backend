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

    public class FilesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public FilesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Files> Get()
        {
            return _dataAccessProvider.GetFilesRecords();
        }

        [HttpGet("{id}")]
        public Files Details(int id)
        {
            return _dataAccessProvider.GetFileRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Files file)
        {
            if (ModelState.IsValid)
            {
                file.updated_at = DateTime.Now;
                _dataAccessProvider.AddFileRecord(file);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Files file)
        {
            if (ModelState.IsValid)
            {
                file.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateFileRecord(file);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var file = _dataAccessProvider.GetFileRecord(id);
            if (file == null)
            {
                return NotFound();
            }
            else
            {
                file.updated_at = DateTime.Now;
                file.is_deleted = true;
                _dataAccessProvider.UpdateFileRecord(file);
            }
            return Ok();
        }

    }
}
