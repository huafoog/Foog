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
	/// 代码生成业务表
	/// </summary>
	[Table(Name = "GenTable")]
	public class GenTableEntity {

		/// <summary>
		/// 编号
		/// </summary>
		public long TableId { get; set; }

		/// <summary>
		/// 生成业务名
		/// </summary>
		public string BusinessName { get; set; }

		/// <summary>
		/// 实体类名称
		/// </summary>
		public string ClassName { get; set; }

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
		/// 数据源名称
		/// </summary>
		public string DataName { get; set; }

		/// <summary>
		/// 生成功能作者
		/// </summary>
		public string FunctionAuthor { get; set; }

		/// <summary>
		/// 生成功能名
		/// </summary>
		public string FunctionName { get; set; }

		/// <summary>
		/// 生成路径（不填默认项目路径）
		/// </summary>
		public string GenPath { get; set; } = "/";

		/// <summary>
		/// 生成代码方式（0zip压缩包 1自定义路径）
		/// </summary>
		public string GenType { get; set; } = "0";

		/// <summary>
		/// 生成模块名
		/// </summary>
		public string ModuleName { get; set; }

		/// <summary>
		/// 其它生成选项
		/// </summary>
		public string Options { get; set; }

		/// <summary>
		/// 生成包路径
		/// </summary>
		public string PackageName { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 子表关联的外键名
		/// </summary>
		public string SubTableFkName { get; set; }

		/// <summary>
		/// 关联子表的表名
		/// </summary>
		public string SubTableName { get; set; }

		/// <summary>
		/// 表描述
		/// </summary>
		public string TableComment { get; set; }

		/// <summary>
		/// 表名称
		/// </summary>
		public string TableName { get; set; }

		/// <summary>
		/// 使用的模板（crud单表操作 tree树表操作）
		/// </summary>
		public string TplCategory { get; set; } = "crud";

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
