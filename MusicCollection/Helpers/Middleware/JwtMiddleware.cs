using MusicCollection.Helpers.Jwt;
using MusicCollection.Services.AccountService;


namespace MusicCollection.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        } 
        
        public async Task Invoke(HttpContext httpContext, IAccountService accountService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var accountId = jwtUtils.ValidateJwtToken(token);

            if(accountId != Guid.Empty)
             {

                httpContext.Items["Account"] = accountService.GetAccountEntityById(accountId);

            }

            await _next(httpContext);
        }
    }
}
