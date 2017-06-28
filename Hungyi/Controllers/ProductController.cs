using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Hungyi.Core.Product;
using Hungyi.DataClass.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hungyi.WebApi.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductModule _productModule;
        public ProductController(IConfiguration configuration)
        {
            _productModule = new OrderModule(configuration);
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<ProductEntity> Get()
        {
            return _productModule.GetAllProduct();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public int Post([FromBody]IEnumerable<ProductEntity> productData)
        {
            return _productModule.InsertProduct(productData);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
