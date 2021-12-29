using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace SpaceMUD.Common.Tools.Attributes.Logging
{
    public class DurationLoggingAttribute : Attribute, IActionFilter
    {
        private Stopwatch stopWatch;
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopWatch.Stop();
            Console.WriteLine($"[Duration Info] Method {filterContext.ActionDescriptor.ActionName} took {stopWatch.ElapsedMilliseconds}ms.");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch = Stopwatch.StartNew();
        }
    }
}
