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
	/// 租户套餐表
	/// </summary>
	[Table(Name = "SysTenantPackage")]
	public class SysTenantPackageEntity {

		/// <summary>
		/// 租户套餐id
		/// </summary>
		public long PackageId { get; set; }

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
		/// 菜单树选择项是否关联显示
		/// </summary>
		public sbyte? MenuCheckStrictly { get; set; } = 1;

		/// <summary>
		/// 关联菜单id
		/// </summary>
		public string MenuIds { get; set; }

		/// <summary>
		/// 套餐名称
		/// </summary>
		public string PackageName { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 状态（0正常 1停用）
		/// </summary>
		public string Status { get; set; } = "0";

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
