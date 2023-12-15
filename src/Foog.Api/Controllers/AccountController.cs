using Foog.Core.Data;
using Foog.Core.Data.Constants;
using Foog.Core.Utilities.Encryption;
using Microsoft.AspNetCore.Mvc;

namespace Foog.Api.Controllers
{
    /// <summary>
    /// 权限
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController 
    {
        private readonly JWTEncryption _JWTEncryption;

        public AccountController(JWTEncryption JWTEncryption)
        {
            _JWTEncryption = JWTEncryption;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<OperationResult<string>> TokenAsync()
        {
            // 生成 token
            var accessToken = _JWTEncryption.Encrypt(new Dictionary<string, object>()
                {
                    { ClaimConst.USERID, "1" },  // 存储Id
                    { ClaimConst.USERNAME,"USERNAME" }, // 存储用户名
                    { ClaimConst.USERNICKNAME,"USERNICKNAME" },
                    { ClaimConst.USEDEPTMENT,"USEDEPTMENT" },
                    { ClaimConst.FOOGCOREUSERISSUPER,true},
                }, 1 * 24 * 60);
            return R.Ok(accessToken);
        }

    }
}
