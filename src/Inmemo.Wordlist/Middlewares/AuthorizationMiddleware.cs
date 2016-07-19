using System.Threading.Tasks;
using Inmemo.Wordlist.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Inmemo.Wordlist.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SecretKeyOptions _secretKeyOptions;

        public AuthorizationMiddleware(RequestDelegate next, IOptions<SecretKeyOptions> secretKeyOptions)
        {
            _next = next;
            _secretKeyOptions = secretKeyOptions.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var authorizationHeader = context.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader) || !_secretKeyOptions.SecretKeys.Contains(authorizationHeader))
            {
                context.Response.StatusCode = 401;
                return;
            }
            await _next.Invoke(context);
        }
    }
}
