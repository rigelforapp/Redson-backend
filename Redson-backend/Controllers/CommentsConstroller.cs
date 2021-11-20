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
            return _dataAccessProvider.GetCommentRecords();
        }

        [HttpGet("{Id}")]
        public Comment Details(int Id)
        {
            return _dataAccessProvider.GetCommentRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Comment comment)
        {
            return CreateEntity(comment);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Comment comment)
        {
            return UpdateEntity(comment);
        }

    }
}
