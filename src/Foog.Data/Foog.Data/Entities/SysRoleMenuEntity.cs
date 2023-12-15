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
	/// 角色和菜单关联表
	/// </summary>
	[Table(Name = "SysRoleMenu")]
	public class SysRoleMenuEntity {

		/// <summary>
		/// 菜单ID
		/// </summary>
		public long MenuId { get; set; }

		/// <summary>
		/// 角色ID
		/// </summary>
		public long RoleId { get; set; }

	}

}
