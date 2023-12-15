using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Foog.Core.Data;

namespace Foog.Api.Filters
{
    public class ApiResponseFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                try
                {
                    context.Result = new ValidErrorObjectResult(R.Error(context.ModelState.Values.First().Errors[0].ErrorMessage));
                }
                catch
                {
                    context.Result = new StatusCodeResult(500);
                }
            }

            base.OnActionExecuting(context);
        }

    }
    /// <summary>
    /// 服务器异常返回
    /// </summary>
    public class ValidErrorObjectResult : ObjectResult
    {
        public ValidErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }

}
