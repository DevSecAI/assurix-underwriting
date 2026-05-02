// ASR-SAST-005: CSRF disabled (no antiforgery configured) on MVC pipeline.
// ASR-SAST-010: session cookie set SameSite=None, Secure=false.
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSession(o =>
{
    o.Cookie.SameSite = SameSiteMode.None;
    o.Cookie.SecurePolicy = CookieSecurePolicy.None;
});

var app = builder.Build();
app.UseSession();
// AntiForgery middleware deliberately not added.
app.MapControllers();
app.Run();
