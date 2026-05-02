// ASR-SAST-009: returns full exception including stack trace.
using Microsoft.AspNetCore.Http;

public class Errors
{
    private readonly RequestDelegate _next;
    public Errors(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext ctx)
    {
        try { await _next(ctx); }
        catch (Exception e)
        {
            ctx.Response.StatusCode = 500;
            await ctx.Response.WriteAsJsonAsync(new
            {
                message = e.Message,
                stack   = e.StackTrace,
                inner   = e.InnerException?.ToString(),
            });
        }
    }
}
