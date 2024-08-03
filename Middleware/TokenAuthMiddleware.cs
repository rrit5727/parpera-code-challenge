namespace TransactionApi.Middleware {

  public class TokenAuthMiddleware
  {
    private readonly RequestDelegate _next;
    private const string TOKEN = "secret-token";

    public TokenAuthMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      if (context.Request.Headers.TryGetValue("Authorization", out var authHeader))
      {
        if (authHeader.ToString().StartsWith("Bearer"))
        {
          var token = authHeader.ToString().Substring("Bearer ".Length).Trim();
          if (token == TOKEN)
          {
            await _next(context);
            return;
          }
        }
      }

      context.Response.StatusCode = 401;
      await context.Response.WriteAsync("Unauthorized");
    }
  }

}