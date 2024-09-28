using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthenticateFilterAttribute:ActionFilterAttribute
{
    
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var userName = context.HttpContext.Request.Headers["userName"];
        if (string.IsNullOrEmpty(userName))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        bool user = _userRepository.UserExists(userName);
        if (user == false)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

    }

}

