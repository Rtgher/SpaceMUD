using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Tools.Attributes.Logging
{
    public class DurationLoggingAsyncAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var sw = Stopwatch.StartNew();
            await next();
            sw.Stop();
            Console.WriteLine($"[Duration Info]Method {context.ActionDescriptor.DisplayName} executed in {sw.ElapsedMilliseconds}ms.");
        }
    }
}
