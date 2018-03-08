using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace DellChallenge.Web2.Filter
{
    public class FilterSession : Attribute, IAsyncResourceFilter
    {
        protected static string SESSION_NAME = "user-on";

        public Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            if (context.HttpContext.Session.TryGetValue(SESSION_NAME, out byte[] usuario))
            {                
                return next();
            }

            context.Result = new RedirectToActionResult("StatusCode/400", "Home", 400);
            return context.Result.ExecuteResultAsync(context);
        }
    }
}
