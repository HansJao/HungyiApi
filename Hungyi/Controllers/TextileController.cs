using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hungyi.DataClass.Textile;
using Hungyi.Core.Textile;
using Microsoft.Extensions.Configuration;
using Hungyi.DataAccess.Textile;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hungyi.WebApi.Controllers
{
    [Route("[controller]")]
    public class TextileController : Controller
    {

        private readonly ITextileModule _textileModule;
        public TextileController(IConfiguration configuration)
        {
            _textileModule = new TextileModule(configuration);
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<AllTextile> Get()
        {
            //var allTextile = new List<AllTextile>()
            //{
            //    new AllTextile
            //    {
            //        TextileName="CVC",
            //        TextileInfo = new List<TextileInfo>
            //        {
            //            new TextileInfo{TextileColor = "black",Amount = 1},
            //            new TextileInfo{TextileColor = "red",Amount = 12},
            //            new TextileInfo{TextileColor = "green",Amount = 54},
            //            new TextileInfo{TextileColor = "yellow",Amount = 33},
            //        }
            //    }
            //};
            return _textileModule.GetAllTextileInfo();
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
