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
	/// 代码生成业务表字段
	/// </summary>
	[Table(Name = "GenTableColumn")]
	public class GenTableColumnEntity {

		/// <summary>
		/// 编号
		/// </summary>
		public long ColumnId { get; set; }

		/// <summary>
		/// 列描述
		/// </summary>
		public string ColumnComment { get; set; }

		/// <summary>
		/// 列名称
		/// </summary>
		public string ColumnName { get; set; }

		/// <summary>
		/// 列类型
		/// </summary>
		public string ColumnType { get; set; }

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
		/// 字典类型
		/// </summary>
		public string DictType { get; set; }

		/// <summary>
		/// 显示类型（文本框、文本域、下拉框、复选框、单选框、日期控件）
		/// </summary>
		public string HtmlType { get; set; }

		/// <summary>
		/// 是否编辑字段（1是）
		/// </summary>
		public string IsEdit { get; set; }

		/// <summary>
		/// 是否自增（1是）
		/// </summary>
		public string IsIncrement { get; set; }

		/// <summary>
		/// 是否为插入字段（1是）
		/// </summary>
		public string IsInsert { get; set; }

		/// <summary>
		/// 是否列表字段（1是）
		/// </summary>
		public string IsList { get; set; }

		/// <summary>
		/// 是否主键（1是）
		/// </summary>
		public string IsPk { get; set; }

		/// <summary>
		/// 是否查询字段（1是）
		/// </summary>
		public string IsQuery { get; set; }

		/// <summary>
		/// 是否必填（1是）
		/// </summary>
		public string IsRequired { get; set; }

		/// <summary>
		/// JAVA字段名
		/// </summary>
		public string JavaField { get; set; }

		/// <summary>
		/// JAVA类型
		/// </summary>
		public string JavaType { get; set; }

		/// <summary>
		/// 查询方式（等于、不等于、大于、小于、范围）
		/// </summary>
		public string QueryType { get; set; } = "EQ";

		/// <summary>
		/// 排序
		/// </summary>
		public int? Sort { get; set; }

		/// <summary>
		/// 归属表编号
		/// </summary>
		public long? TableId { get; set; }

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
