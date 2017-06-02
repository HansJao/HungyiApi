using Hungyi.Core.User;
using Hungyi.DataAccess.User;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hungyi.WebApi.Filter
{
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{//Response.StatusCode = (int) HttpStatusCode.Unauthorized;
        //    //context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        //    base.OnActionExecuted(context);
        //}

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            UserModule userModule = new UserModule(new UserDao("Data Source=hansjao\\hansdb;Initial Catalog=HY;User ID=sa;Password=yuiop7410;"));
            var authInfo = (string)context.HttpContext.Request.Headers["Authorization"];
            //context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authInfo);
            if (authInfo == null)
            {                
                return;
            }
            var userInfo = authInfo.Split(':');

            var isAuth = userModule.CheckToken(userInfo[0], userInfo[1]);
            if (!isAuth)
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //base.OnActionExecuting(context);
        }
    }
}
