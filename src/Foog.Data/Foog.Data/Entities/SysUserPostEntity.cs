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
	/// 用户与岗位关联表
	/// </summary>
	[Table(Name = "SysUserPost")]
	public class SysUserPostEntity {

		/// <summary>
		/// 岗位ID
		/// </summary>
		public long PostId { get; set; }

		/// <summary>
		/// 用户ID
		/// </summary>
		public long UserId { get; set; }

	}

}
