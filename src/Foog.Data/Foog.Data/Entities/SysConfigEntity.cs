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
	/// 参数配置表
	/// </summary>
	[Table(Name = "SysConfig")]
	public class SysConfigEntity {

		/// <summary>
		/// 参数主键
		/// </summary>
		public long ConfigId { get; set; }

		/// <summary>
		/// 参数键名
		/// </summary>
		public string ConfigKey { get; set; }

		/// <summary>
		/// 参数名称
		/// </summary>
		public string ConfigName { get; set; }

		/// <summary>
		/// 系统内置（Y是 N否）
		/// </summary>
		public string ConfigType { get; set; } = "N";

		/// <summary>
		/// 参数键值
		/// </summary>
		public string ConfigValue { get; set; }

		/// <summary>
		/// 创建者
		/// </summary>
		public long? CreateBy { get; set; }

		/// <summary>
		/// 创建部门
		/// </summary>
		public long? CreateDept { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 租户编号
		/// </summary>
		public string TenantId { get; set; } = "000000";

		/// <summary>
		/// 更新者
		/// </summary>
		public long? UpdateBy { get; set; }

		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime? UpdateTime { get; set; }

	}

}
