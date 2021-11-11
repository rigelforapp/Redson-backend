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

    public class CategoriesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public CategoriesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Categories> Get()
        {
            return _dataAccessProvider.GetCategoriesRecords();
        }

        [HttpGet("{id}")]
        public Categories Details(int id)
        {
            return _dataAccessProvider.GetCategoryRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Categories category)
        {
            if (ModelState.IsValid)
            {
                category.updated_at = DateTime.Now;
                _dataAccessProvider.AddCategoryRecord(category);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Categories category)
        {
            if (ModelState.IsValid)
            {
                category.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateCategoryRecord(category);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _dataAccessProvider.GetCategoryRecord(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                category.updated_at = DateTime.Now;
                category.is_deleted = true;
                _dataAccessProvider.UpdateCategoryRecord(category);
            }
            return Ok();
        }

    }
}
