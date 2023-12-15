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
	/// 角色和部门关联表
	/// </summary>
	[Table(Name = "SysRoleDept")]
	public class SysRoleDeptEntity {

		/// <summary>
		/// 部门ID
		/// </summary>
		public long DeptId { get; set; }

		/// <summary>
		/// 角色ID
		/// </summary>
		public long RoleId { get; set; }

	}

}
