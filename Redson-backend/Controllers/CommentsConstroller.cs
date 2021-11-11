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

    public class CommentsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public CommentsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Comments> Get()
        {
            return _dataAccessProvider.GetCommentsRecords();
        }

        [HttpGet("{id}")]
        public Comments Details(int id)
        {
            return _dataAccessProvider.GetCommentRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Comments comment)
        {
            if (ModelState.IsValid)
            {
                comment.updated_at = DateTime.Now;
                _dataAccessProvider.AddCommentRecord(comment);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Comments comment)
        {
            if (ModelState.IsValid)
            {
                comment.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateCommentRecord(comment);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var comment = _dataAccessProvider.GetCommentRecord(id);
            if (comment == null)
            {
                return NotFound();
            }
            else
            {
                comment.updated_at = DateTime.Now;
                comment.is_deleted = true;
                _dataAccessProvider.UpdateCommentRecord(comment);
            }
            return Ok();
        }

    }
}
