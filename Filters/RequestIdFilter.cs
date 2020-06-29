using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DependencyInjection.Filters
{
	public class RequestIdFilter : IActionFilter
    {
        private readonly IRequestIdGenerator requestIdGenerator;

		public RequestIdFilter(IRequestIdGenerator requestIdGenerator)
		{
            this.requestIdGenerator = requestIdGenerator;
        }

		public void OnActionExecuted(ActionExecutedContext context)
		{
			ConsoleLogger.Instance.Log("Adding a request-id to the response: " + this.requestIdGenerator.RequestId);
			context.HttpContext.Response.Headers.Add("request-id", new string[] { this.requestIdGenerator.RequestId });
        }

		public void OnActionExecuting(ActionExecutingContext context)
		{
			// nothing to do here, but have to have this method because the interface requires it
		}
	}
}
