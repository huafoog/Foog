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
	/// 系统访问记录
	/// </summary>
	[Table(Name = "SysLogininfor")]
	public class SysLogininforEntity {

		/// <summary>
		/// 访问ID
		/// </summary>
		public long InfoId { get; set; }

		/// <summary>
		/// 浏览器类型
		/// </summary>
		public string Browser { get; set; }

		/// <summary>
		/// 登录IP地址
		/// </summary>
		public string Ipaddr { get; set; }

		/// <summary>
		/// 登录地点
		/// </summary>
		public string LoginLocation { get; set; }

		/// <summary>
		/// 访问时间
		/// </summary>
		public DateTime? LoginTime { get; set; }

		/// <summary>
		/// 提示消息
		/// </summary>
		public string Msg { get; set; }

		/// <summary>
		/// 操作系统
		/// </summary>
		public string Os { get; set; }

		/// <summary>
		/// 登录状态（0成功 1失败）
		/// </summary>
		public string Status { get; set; } = "0";

		/// <summary>
		/// 租户编号
		/// </summary>
		public string TenantId { get; set; } = "000000";

		/// <summary>
		/// 用户账号
		/// </summary>
		public string UserName { get; set; }

	}

}
