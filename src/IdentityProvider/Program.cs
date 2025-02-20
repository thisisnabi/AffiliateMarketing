var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/auth/signup", () =>
{

}).AddEndpointFilter<AffiliateSignUpFilter>();


app.Run();
 

public class AffiliateSignUpFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {

        var result = await next(context);


        CheckAffliateReuqest(context.HttpContext);

        static void CheckAffliateReuqest(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("affiliate_code"))
            {
                var affiliateCode = httpContext.Request.Query["affiliate_code"].ToString();

                var options = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(30),
                    Secure = httpContext.Request.IsHttps,
                    SameSite = SameSiteMode.Lax
                };

                httpContext.Response.Cookies.Append("__affiliate_code", affiliateCode, options);
            }
        }

        return result;
    }
}