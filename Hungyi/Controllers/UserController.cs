using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hungyi.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Hungyi.DataAccess.User;
using Hungyi.Core.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hungyi.WebApi.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserModule _userModule;
        public UserController(IConfiguration configuration)
        {
            _userModule = new UserModule(new UserDao(configuration.GetValue<string>("DBInfo:ConnectionString")));
        }
        [HttpGet]
        public UserEntity Info()
        {
            var authorization = HttpContext.Request.Headers["Authorization"];
            var date = HttpContext.Request.Headers["Datetime"];
            var account = HttpContext.Request.Headers["Account"];
            var password = HttpContext.Request.Headers["Password"];
            var result = _userModule.UserLogin(account, password);
            return result;
        }
    }
}
