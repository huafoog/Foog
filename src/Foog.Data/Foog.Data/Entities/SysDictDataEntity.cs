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
	/// 字典数据表
	/// </summary>
	[Table(Name = "SysDictData")]
	public class SysDictDataEntity {

		/// <summary>
		/// 字典编码
		/// </summary>
		public long DictCode { get; set; }

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
		/// 样式属性（其他样式扩展）
		/// </summary>
		public string CssClass { get; set; }

		/// <summary>
		/// 字典标签
		/// </summary>
		public string DictLabel { get; set; }

		/// <summary>
		/// 字典排序
		/// </summary>
		public int? DictSort { get; set; } = 0;

		/// <summary>
		/// 字典类型
		/// </summary>
		public string DictType { get; set; }

		/// <summary>
		/// 字典键值
		/// </summary>
		public string DictValue { get; set; }

		/// <summary>
		/// 是否默认（Y是 N否）
		/// </summary>
		public string IsDefault { get; set; } = "N";

		/// <summary>
		/// 表格回显样式
		/// </summary>
		public string ListClass { get; set; }

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
