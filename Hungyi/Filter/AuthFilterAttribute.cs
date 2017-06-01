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
        public override void OnActionExecuted(ActionExecutedContext context)
        {//Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            //context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            base.OnActionExecuted(context);
        }
    }
}
