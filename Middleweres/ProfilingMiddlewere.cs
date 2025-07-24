using System.Diagnostics;

namespace AspNetCoreForBeginners.Middleweres;

public class ProfilingMiddlewere
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ProfilingMiddlewere> _logger;

    public ProfilingMiddlewere(RequestDelegate next, ILogger<ProfilingMiddlewere> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        await _next(context);
        stopwatch.Stop();
        _logger.LogInformation($"Request '{context.Request.Path}' took '{stopwatch.ElapsedMilliseconds}ms' to excute");
    }
}

