﻿using Microsoft.Extensions.DependencyInjection;
namespace Foog.Core.DependencyInjection
{
    /// <summary>
    /// 作用域服务注册依赖
    /// <para>实现此接口的类型将自动注册为<see cref="ServiceLifetime.Scoped"/>模式</para>
    /// </summary>
    public interface IScopeDependency : IDependency
    {
    }
}