using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TransactionApi.Authentication
{
    public class CustomAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string TOKEN = "secret-token"; // 

        public CustomAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                if (authHeader.ToString().StartsWith("Bearer"))
                {
                    var token = authHeader.ToString().Substring("Bearer ".Length).Trim();
                    if (token == TOKEN)
                    {
                        var claims = new[] { new Claim(ClaimTypes.Name, "example") };
                        var identity = new ClaimsIdentity(claims, "Custom");
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal, "Custom");

                        return Task.FromResult(AuthenticateResult.Success(ticket));
                    }
                }
            }

            return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));
        }
    }
}