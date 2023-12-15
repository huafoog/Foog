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
	/// 部门表
	/// </summary>
	[Table(Name = "SysDept")]
	public class SysDeptEntity {

		/// <summary>
		/// 部门id
		/// </summary>
		public long DeptId { get; set; }

		/// <summary>
		/// 祖级列表
		/// </summary>
		public string Ancestors { get; set; }

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
		/// 部门名称
		/// </summary>
		public string DeptName { get; set; }

		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// 负责人
		/// </summary>
		public long? Leader { get; set; }

		/// <summary>
		/// 显示顺序
		/// </summary>
		public int? OrderNum { get; set; } = 0;

		/// <summary>
		/// 父部门id
		/// </summary>
		public long? ParentId { get; set; } = 0;

		/// <summary>
		/// 联系电话
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// 部门状态（0正常 1停用）
		/// </summary>
		public string Status { get; set; } = "0";

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
