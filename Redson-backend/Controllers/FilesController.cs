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

    public class FilesController : GenericC
    {

        public FilesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "File";
        }

        [HttpGet]
        public IEnumerable<File> Get()
        {
            return _dataAccessProvider.GetFileRecords();
        }

        [HttpGet("{Id}")]
        public File Details(int Id)
        {
            return _dataAccessProvider.GetFileRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] File file)
        {
            return CreateEntity(file);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] File file)
        {
            return UpdateEntity(file);
        }

    }
}
