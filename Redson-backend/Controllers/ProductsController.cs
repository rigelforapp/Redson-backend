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

    public class ProductsController : GenericC
    {

        public ProductsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Product";
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return (List<Product>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Product Details(int id)
        {
            return (Product)GetEntity(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Product entity)
        {
            return UpdateEntity(entity);
        }

    }
}
