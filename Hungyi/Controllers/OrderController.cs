using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hungyi.DataClass.Order;
using Microsoft.Extensions.Configuration;
using Hungyi.Core.Order;
using Hungyi.Core.Textile;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hungyi.WebApi.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderModule _orderModule;
        private readonly ITextileModule _textieModule;
        public OrderController(IConfiguration configuration)
        {
            _orderModule = new OrderModule(configuration);
            _textieModule = new TextileModule(configuration);
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [Route("SendShipmentInfo")]
        [HttpPost]
        public void Post([FromBody]ShipmentInfo shipmentInfo)
        {
            bool success = false;
            success = _textieModule.UpdateTextileIsSold(shipmentInfo.Textile, shipmentInfo.CustomerID);
            if(success)
            {
                int orderID = _orderModule.CreateOrder(shipmentInfo);
            }
            //_orderModule.SendShipmentInfo(shipmentInfo);
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
