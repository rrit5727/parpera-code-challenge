using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace TransactionApi.Authentication {
  public class CustomAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
  {
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
          // Implement your custom authentication logic here

          // Example: Create a claims identity and return success
          var claims = new[] { new Claim(ClaimTypes.Name, "example") };
          var identity = new ClaimsIdentity(claims, "Custom");
          var principal = new ClaimsPrincipal(identity);
          var ticket = new AuthenticationTicket(principal, "Custom");

          return Task.FromResult(AuthenticateResult.Success(ticket));
      }
  }

  
}

