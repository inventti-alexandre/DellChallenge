using DellChallenge.Domain.EnititiesViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            context.Result = new RedirectToActionResult("StatusCode/401", "Home", 401);
            return context.Result.ExecuteResultAsync(context);
        }
    }
}
