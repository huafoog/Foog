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
	/// 用户和角色关联表
	/// </summary>
	[Table(Name = "SysUserRole")]
	public class SysUserRoleEntity {

		/// <summary>
		/// 角色ID
		/// </summary>
		public long RoleId { get; set; }

		/// <summary>
		/// 用户ID
		/// </summary>
		public long UserId { get; set; }

	}

}
