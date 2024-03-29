﻿namespace Foog.Core.Permission
{
    /// <summary>
    /// 用户信息接口服务
    /// </summary>
    public interface IUserInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 用户名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 昵称
        /// </summary>
        string NickName { get; }

        bool IsSuper { get; }
    }
}
