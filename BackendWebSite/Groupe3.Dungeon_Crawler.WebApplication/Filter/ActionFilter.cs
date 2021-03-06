using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Groupe3.Dungeon_Crawler.WebApplication.Filter
{
    public class ActionFilter : IActionFilter
    {
        private readonly ILogger _logger;
        public ActionFilter(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<ActionFilter>();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            StringBuilder message = new StringBuilder("Output : ");
            foreach (var item in context.RouteData.Values)
            {
                message.Append(item);
            }
            string result = ($"{message} Http Request Information: {context.HttpContext.Request.Method}");
            _logger.LogInformation(result);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            StringBuilder message = new StringBuilder("Input : ");

            foreach (var item in context.RouteData.Values)
            {
                message.Append(item);
            }
            string result= ($"{message} Http Request Information: {context.HttpContext.Request.Method}");
            _logger.LogInformation(result);
        }

        public void OnException(ExceptionContext context)
        {
            string result = ("Error : " + context.Exception);
            _logger.LogError(result);
        }
    }
}
