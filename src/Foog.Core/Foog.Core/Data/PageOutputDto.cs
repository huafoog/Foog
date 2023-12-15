using Foog.Core.Converts;

namespace Foog.Core.Data
{
    /// <summary>
    /// 分页信息输出
    /// </summary>
    public class PageOutputDto<T>:OperationResult
    {
        /// <summary>
        /// 数据总数
        /// </summary>
        public long TotalCount { get; set; } = 0;

        public long TotalPage=> TotalCount.Division(PageSize).Ceiling().ToLong();

        public int PageNo { get; set; }

        public int PageSize { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public new IList<T> Data { get; set; }
    }
}
