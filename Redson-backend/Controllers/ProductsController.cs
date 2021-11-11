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

    public class ProductsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public ProductsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return _dataAccessProvider.GetProductsRecords();
        }

        [HttpGet("{id}")]
        public Products Details(int id)
        {
            return _dataAccessProvider.GetProductRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Products product)
        {
            if (ModelState.IsValid)
            {
                product.updated_at = DateTime.Now;
                _dataAccessProvider.AddProductRecord(product);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Products product)
        {
            if (ModelState.IsValid)
            {
                product.updated_at = DateTime.Now;
                _dataAccessProvider.UpdateProductRecord(product);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _dataAccessProvider.GetProductRecord(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                product.updated_at = DateTime.Now;
                product.is_deleted = true;
                _dataAccessProvider.UpdateProductRecord(product);
            }
            return Ok();
        }

    }
}
