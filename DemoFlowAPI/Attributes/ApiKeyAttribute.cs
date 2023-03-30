using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebshopAPI.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            #region Admin Key Value
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key was not provided!"
                };
                return;
            }
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var adminApiKey = appSettings.GetValue<string>(APIKEYNAME);
            #endregion
            //Check if api key provided is admin key
            if (!adminApiKey.Equals(extractedApiKey)) {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api key in not valid!"
                };
                return;
            }
            await next();
        }
    }
}
