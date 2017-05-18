using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Hungyi.Core;
using Hungyi.DataAccess;
using Hungyi.DataAccess.User;
using Hungyi.DataAccess.Models;

namespace Hungyi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly UserDao userDao;
        public ValuesController(IConfiguration configuration)
        {
            userDao = new UserDao(configuration.GetValue<string>("DBInfo:ConnectionString"));
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<UserEntity> Get()
        {
            return userDao.GetAllUser();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
