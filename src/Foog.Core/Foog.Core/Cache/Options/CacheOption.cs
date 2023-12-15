using Foog.Core.Cache.Models;
using System.ComponentModel.DataAnnotations;

namespace Foog.Core.Cache.Options
{

    /// <summary>
    /// 
    /// </summary>
    [Display(Name = "Cache")]
    public sealed class CacheOption
    {
        /// <summary>
        /// 缓存方式 Redis Memory
        /// </summary>
        public string CacheWay { get; set; }
        public CacheInfo Redis { get; set; }
    }
}
