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
	/// 岗位信息表
	/// </summary>
	[Table(Name = "SysPost")]
	public class SysPostEntity {

		/// <summary>
		/// 岗位ID
		/// </summary>
		public long PostId { get; set; }

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
		/// 岗位编码
		/// </summary>
		public string PostCode { get; set; }

		/// <summary>
		/// 岗位名称
		/// </summary>
		public string PostName { get; set; }

		/// <summary>
		/// 显示顺序
		/// </summary>
		public int PostSort { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 状态（0正常 1停用）
		/// </summary>
		public string Status { get; set; }

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
