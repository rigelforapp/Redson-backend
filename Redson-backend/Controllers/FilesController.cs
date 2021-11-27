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
            return (List<File>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public File Details(int id)
        {
            return (File)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] File entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] File entity)
        {
            return UpdateEntity(entity);
        }

    }
}
