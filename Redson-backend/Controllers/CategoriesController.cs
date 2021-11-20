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

    public class CategoriesController : GenericC
    {

        public CategoriesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Category";
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _dataAccessProvider.GetCategoryRecords();
        }

        [HttpGet("{Id}")]
        public Category Details(int Id)
        {
            return _dataAccessProvider.GetCategoryRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            return CreateEntity(category);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Category category)
        {
            return UpdateEntity(category);
        }

    }
}
