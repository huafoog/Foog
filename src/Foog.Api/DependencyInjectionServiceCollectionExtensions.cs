using Foog.Core.Data;
using Foog.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using System.Runtime.Loader;

namespace Foog.Api
{
    public static class DependencyInjectionServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.RegisterLifetimes();
        }
        private static void RegisterLifetimes(this IServiceCollection services)
        {
            var assemblies = GetAssemblies();
            if (assemblies == null) return;
            // 获取所有能注册的接口
            List<Type> canInjectTypes = GetAssemblies()
                .SelectMany(x => x.GetTypes()).Where(o => o.IsClass && !o.IsAbstract && typeof(IDependency).IsAssignableFrom(o)
                ).ToList();
            foreach (var type in canInjectTypes)
            {
                var canInjectInterfaces = type.GetInterfaces().Where(u => !typeof(IDependency).IsAssignableFrom(u));
                var canInjectInterface = canInjectInterfaces.FirstOrDefault();
                if (canInjectInterface == null) continue;
                if (typeof(ITransientDependency).IsAssignableFrom(type))
                {
                    services.TryAddTransient(canInjectInterface, type);
                }
                // 注册作用域服务
                else if (typeof(IScopeDependency).IsAssignableFrom(type))
                {
                    services.TryAddScoped(canInjectInterface, type);
                }
                // 注册单例服务
                else if (typeof(ISingletonDependency).IsAssignableFrom(type))
                {
                    services.TryAddSingleton(canInjectInterface, type);
                }
            }
        }
         /// <summary>
        /// 获取项目程序集
        /// </summary>
        /// <returns>IEnumerable</returns>
        private static IEnumerable<Assembly> GetAssemblies()
        {
            var list = DependencyContext.Default?.CompileLibraries
              .Where(u => u.Type == "project" && u.Name.EndsWith("Service"))    // 判断是否启用引用程序集扫描
              .Select(u => AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(u.Name)))
              .ToList();//排除所有的系统程序集、Nuget下载包
            return list;
        }
    }
}
