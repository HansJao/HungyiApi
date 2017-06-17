using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hungyi.Core.Customer;
using Microsoft.Extensions.Configuration;
using Hungyi.DataClass.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hungyi.WebApi.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerModule _customerModule;
        public CustomerController(IConfiguration configuration)
        {
            _customerModule = new CustomerModule(configuration);
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<CustomerEntity> Get()
        {
            return _customerModule.GetAllCustomerInfo();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]IEnumerable<CustomerEntity> customerEntity)
        {
            return _customerModule.AddCustomerList(customerEntity);
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
