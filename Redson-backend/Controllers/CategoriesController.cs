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
            return (List<Category>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Category Details(int id)
        {
            return (Category)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Category entity)
        {
            return UpdateEntity(entity);
        }

    }
}
