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

    public class CommentsController : GenericC
    {

        public CommentsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Comment";
        }

        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return (List<Comment>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Comment Details(int id)
        {
            return (Comment)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Comment entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Comment entity)
        {
            return UpdateEntity(entity);
        }

    }
}
