using FreeSql.DatabaseModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;
using Foog.Core.DatabaseAccessor;

namespace LinCms.Core.Entities
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Table(Name = "SysUser")]
    public class SysUserEntity : EntityBase
    {
        /// <summary>
        /// 头像地址
        /// </summary>
        public string? Avatar { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LoginDate { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LoginIp { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phonenumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 用户性别（0男 1女 2未知）
        /// </summary>
        public string Sex { get; set; } = "0";

        /// <summary>
        /// 帐号状态（0正常 1停用）
        /// </summary>
        public string Status { get; set; } = "0";

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户类型（sys_user系统用户）
        /// </summary>
        public string UserType { get; set; } = "sys_user";

    }

}
