using Microsoft.AspNetCore.Authorization;

namespace Foog.Core.Permission
{
    /// <summary>
    /// 权限代码
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class PermissionAttribute : Attribute,IAuthorizationRequirement
    {
        public PermissionAttribute()
        {
            
        }

        public PermissionAttribute(string code)
        {
            Code = code;
        }
        public string Code { get; set; }

        public int Age { get; set; }
    }
}
