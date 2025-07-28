using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Principal;
using System.Text.Json;

namespace ProductManagementAPI.Filters;

public class LogActivityFilter : IActionFilter, IAsyncActionFilter
{
    private readonly ILogger<LogActivityFilter> _logger;
    public LogActivityFilter(ILogger<LogActivityFilter> logger)
    {
        _logger = logger;
    }
    void IActionFilter.OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation($"Excuting action {context.ActionDescriptor.DisplayName} on controller {context.Controller} with arguments {JsonSerializer.Serialize(context.ActionArguments)}");
    }
    void IActionFilter.OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} Finished exction on Controller{context.Controller}");
        context.Result = new NotFoundResult();
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _logger.LogInformation($"(Aync) exction action {context.ActionDescriptor.DisplayName} on controller {context.Controller}");
        await next();
        _logger.LogInformation($"(Async) Action {context.ActionDescriptor.DisplayName} Finished exction on Controller{context.Controller}");
    }
}
