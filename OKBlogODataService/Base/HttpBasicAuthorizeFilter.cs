using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace OKBlogODataService.Base
{
    public class HttpBasicAuthorizeFilter : IActionFilter
    {
        private const string ApiKey = "1234567890";

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Query.TryGetValue("ApiKey", out StringValues apiKey))
            {
                if (apiKey.ToString().Equals(ApiKey))
                {
                    return;
                }
            }
            context.Result = new UnauthorizedResult();
        }
    }
}
