using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace MUS.Common.Tools.Attributes.Logging
{
    public class DurationLoggingAttribute : Attribute, IActionFilter
    {
        private Stopwatch stopWatch;
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopWatch.Stop();
            Console.WriteLine($"[Duration Info] Method {filterContext.ActionDescriptor.DisplayName} took {stopWatch.ElapsedMilliseconds}ms.");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch = Stopwatch.StartNew();
        }
    }
}
