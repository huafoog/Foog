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
	/// 角色信息表
	/// </summary>
	[Table(Name = "SysRole")]
	public class SysRoleEntity {

		/// <summary>
		/// 角色ID
		/// </summary>
		public long RoleId { get; set; }

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
		/// 数据范围（1：全部数据权限 2：自定数据权限 3：本部门数据权限 4：本部门及以下数据权限）
		/// </summary>
		public string DataScope { get; set; } = "1";

		/// <summary>
		/// 删除标志（0代表存在 2代表删除）
		/// </summary>
		public string DelFlag { get; set; } = "0";

		/// <summary>
		/// 部门树选择项是否关联显示
		/// </summary>
		public sbyte? DeptCheckStrictly { get; set; } = 1;

		/// <summary>
		/// 菜单树选择项是否关联显示
		/// </summary>
		public sbyte? MenuCheckStrictly { get; set; } = 1;

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 角色权限字符串
		/// </summary>
		public string RoleKey { get; set; }

		/// <summary>
		/// 角色名称
		/// </summary>
		public string RoleName { get; set; }

		/// <summary>
		/// 显示顺序
		/// </summary>
		public int RoleSort { get; set; }

		/// <summary>
		/// 角色状态（0正常 1停用）
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
