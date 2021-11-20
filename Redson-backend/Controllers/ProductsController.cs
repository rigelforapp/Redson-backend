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
            return _dataAccessProvider.GetProductRecords();
        }

        [HttpGet("{Id}")]
        public Product Details(int Id)
        {
            return _dataAccessProvider.GetProductRecord(Id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            return CreateEntity(product);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Product product)
        {
            return UpdateEntity(product);
        }

    }
}
