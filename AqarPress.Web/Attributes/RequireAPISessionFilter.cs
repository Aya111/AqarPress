using AqarPress.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace AqarPress.Web.Attributes
{
    public class RequireAPISession : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                var containsHeader = context.HttpContext.Request.Headers.ContainsKey(Config.API_SESSION_HEADER);

                if (!containsHeader)
                {
                    context.Result = new BadRequestObjectResult($"Session header should be sent");
                }
                else
                {
                    var headerSession = context.HttpContext.Request.Headers[Config.API_SESSION_HEADER];

                    var id = context.HttpContext.RequestServices.GetService(typeof(IdentityService)) as IdentityService;
                    var userSession = id.GetSession(headerSession);

                    if (userSession == null)
                    {
                        context.Result = new BadRequestObjectResult($"Session header {headerSession} not found or valid");
                    }

                    context.HttpContext.Items.Add(Config.API_SESSION_OBJECT, userSession);
                }
            }
        }
    }
}