using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DependencyInjection.Filters
{
	/*
		This class times how long a request takes to execute and then adds the result to a response header.
	*/
	public class StopwatchFilter : IActionFilter
	{
        private readonly StopwatchService watchService;

        public StopwatchFilter(StopwatchService watchService)
        {
            this.watchService = watchService;
        }

		public void OnActionExecuted(ActionExecutedContext context)
		{
			this.watchService.Lap("Action Executed");
			context.HttpContext.Response.Headers.Add("stopwatch", new string[] { this.watchService.ToString() });
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			this.watchService.Start("Action Executing");
		}
	}
}
