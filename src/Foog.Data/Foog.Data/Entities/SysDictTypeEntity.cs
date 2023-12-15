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
	/// 字典类型表
	/// </summary>
	[Table(Name = "SysDictType")]
	public class SysDictTypeEntity {

		/// <summary>
		/// 字典主键
		/// </summary>
		public long DictId { get; set; }

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
		/// 字典名称
		/// </summary>
		public string DictName { get; set; }

		/// <summary>
		/// 字典类型
		/// </summary>
		public string DictType { get; set; }

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
