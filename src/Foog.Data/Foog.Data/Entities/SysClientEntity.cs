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
	/// 系统授权表
	/// </summary>
	[Table(Name = "SysClient")]
	public class SysClientEntity {

		/// <summary>
		/// id
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// token活跃超时时间
		/// </summary>
		public int? ActiveTimeout { get; set; } = 1800;

		/// <summary>
		/// 客户端id
		/// </summary>
		public string ClientId { get; set; }

		/// <summary>
		/// 客户端key
		/// </summary>
		public string ClientKey { get; set; }

		/// <summary>
		/// 客户端秘钥
		/// </summary>
		public string ClientSecret { get; set; }

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
		/// 删除标志（0代表存在 2代表删除）
		/// </summary>
		public string DelFlag { get; set; } = "0";

		/// <summary>
		/// 设备类型
		/// </summary>
		public string DeviceType { get; set; }

		/// <summary>
		/// 授权类型
		/// </summary>
		public string GrantType { get; set; }

		/// <summary>
		/// 状态（0正常 1停用）
		/// </summary>
		public string Status { get; set; } = "0";

		/// <summary>
		/// token固定超时
		/// </summary>
		public int? Timeout { get; set; } = 604800;

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
