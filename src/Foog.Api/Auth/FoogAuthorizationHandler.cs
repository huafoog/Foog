using Foog.Api.Filters;
using Foog.Core.Data;
using Foog.Core.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Foog.Api.Auth
{
    /// <summary>
    /// 全局授权筛选
    /// </summary>
    public class FoogAuthorizationHandler : IAuthorizationHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FoogAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context == null)
            {
                // 授权失败响应信息
                await ResponseMessage();
                context.Fail();
                return;
            }
            if (!context.User.Identity.IsAuthenticated)
            {
                await ResponseMessage();
                context.Fail();
                return;
            }
            HttpContext httpContext = context.Resource as HttpContext;
            if (httpContext != null)
            {
                string[] currentCode = new String[] { "App.Code", "App.Code1", "App.Code2" };
                PermissionAttribute permission = (PermissionAttribute)httpContext.GetEndpoint().Metadata.Where(o => o.GetType() == typeof(PermissionAttribute)).FirstOrDefault();
                if (permission == null)
                {
                    //context.Succeed(context.PendingRequirements.FirstOrDefault());
                    return;
                }
                if (currentCode.Contains(permission.Code))
                {
                    //context.Succeed(context.PendingRequirements.FirstOrDefault());
                    return;
                }
            }
            await ResponseMessage();
            context.Fail();
            return;
        }
        private async Task ResponseMessage()
        {
            _httpContextAccessor.HttpContext.Response.StatusCode = 401;
            _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
            await _httpContextAccessor.HttpContext.Response.WriteAsync(R.Error("未授权访问").ToString());
        }
    }
}
