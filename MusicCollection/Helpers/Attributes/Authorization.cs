using DAL.Models;
using DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MusicCollection.Helpers.Attributes
{
    public class AuthorizationAttribute:Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public AuthorizationAttribute(params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult(new { Message = "Unauthorized" })
            { StatusCode = StatusCodes.Status401Unauthorized };

            if(_roles == null)
            {
                context.Result = unauthorizedStatusObject;
            }

          
            Account? account = context.HttpContext.Items["Account"] as Account;

            if (account == null || !_roles.Contains(account.Role))
            {
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
