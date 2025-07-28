﻿
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ProductManagementAPI.Middleweres;

public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;

    private static int _counter = 0;
    private static DateTime _lastRequestDate = DateTime.Now;
    public RateLimitingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        _counter++;
        if (DateTime.Now.Subtract(_lastRequestDate).Seconds > 10)
        {
            _counter = 1;
            _lastRequestDate = DateTime.Now;
            await _next(context);
        }
        else
        {
            if (_counter > 5)
            {
                _lastRequestDate = DateTime.Now;
                context.Response.StatusCode = 429;
                context.Response.Headers["ratelimit-message"] = "Rate Limit Exceeded";
                await context.Response.CompleteAsync();
            }
            else
            {
                _lastRequestDate = DateTime.Now;
                await _next(context);
            }
        }

    }



}
