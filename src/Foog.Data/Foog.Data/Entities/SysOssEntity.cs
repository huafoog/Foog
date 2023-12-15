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
	/// OSS对象存储表
	/// </summary>
	[Table(Name = "SysOss")]
	public class SysOssEntity {

		/// <summary>
		/// 对象存储主键
		/// </summary>
		public long OssId { get; set; }

		/// <summary>
		/// 上传人
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
		/// 文件名
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// 文件后缀名
		/// </summary>
		public string FileSuffix { get; set; }

		/// <summary>
		/// 原名
		/// </summary>
		public string OriginalName { get; set; }

		/// <summary>
		/// 服务商
		/// </summary>
		public string Service { get; set; } = "minio";

		/// <summary>
		/// 租户编号
		/// </summary>
		public string TenantId { get; set; } = "000000";

		/// <summary>
		/// 更新人
		/// </summary>
		public long? UpdateBy { get; set; }

		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime? UpdateTime { get; set; }

		/// <summary>
		/// URL地址
		/// </summary>
		public string Url { get; set; }

	}

}
