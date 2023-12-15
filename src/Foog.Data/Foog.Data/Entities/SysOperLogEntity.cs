using FreeSql.DatabaseModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace LinCms.Core.Entities {

	/// <summary>
	/// 操作日志记录
	/// </summary>
	[Table(Name = "SysOperLog")]
	public class SysOperLogEntity {

		/// <summary>
		/// 日志主键
		/// </summary>
		public long OperId { get; set; }

		/// <summary>
		/// 业务类型（0其它 1新增 2修改 3删除）
		/// </summary>
		public int? BusinessType { get; set; } = 0;

		/// <summary>
		/// 消耗时间
		/// </summary>
		public long? CostTime { get; set; } = 0;

		/// <summary>
		/// 部门名称
		/// </summary>
		public string DeptName { get; set; }

		/// <summary>
		/// 错误消息
		/// </summary>
		public string ErrorMsg { get; set; }

		/// <summary>
		/// 返回参数
		/// </summary>
		public string JsonResult { get; set; }

		/// <summary>
		/// 方法名称
		/// </summary>
		public string Method { get; set; }

		/// <summary>
		/// 主机地址
		/// </summary>
		public string OperIp { get; set; }

		/// <summary>
		/// 操作地点
		/// </summary>
		public string OperLocation { get; set; }

		/// <summary>
		/// 操作人员
		/// </summary>
		public string OperName { get; set; }

		/// <summary>
		/// 请求参数
		/// </summary>
		public string OperParam { get; set; }

		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? OperTime { get; set; }

		/// <summary>
		/// 请求URL
		/// </summary>
		public string OperUrl { get; set; }

		/// <summary>
		/// 操作类别（0其它 1后台用户 2手机端用户）
		/// </summary>
		public int? OperatorType { get; set; } = 0;

		/// <summary>
		/// 请求方式
		/// </summary>
		public string RequestMethod { get; set; }

		/// <summary>
		/// 操作状态（0正常 1异常）
		/// </summary>
		public int? Status { get; set; } = 0;

		/// <summary>
		/// 租户编号
		/// </summary>
		public string TenantId { get; set; } = "000000";

		/// <summary>
		/// 模块标题
		/// </summary>
		public string Title { get; set; }

	}

}
