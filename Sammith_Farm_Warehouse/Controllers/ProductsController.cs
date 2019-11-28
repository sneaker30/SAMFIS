using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sammith_Farm_Warehouse.Models;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sammith_Farm_Warehouse.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        public AppDB Db { get; }

        public ProductsController(AppDB db)
        {
            Db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var query = new Products(Db);
            var result = query.GetProdctsAsync("all", "20");

            return new OkObjectResult(result);
        }

        [HttpGet("{pro_id}")]
        public IActionResult GetById(int pro_id)
        {
            var query = new Products(Db);
            var result = query.GetProdctsAsync(pro_id.ToString(), "20");

            return new OkObjectResult(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}