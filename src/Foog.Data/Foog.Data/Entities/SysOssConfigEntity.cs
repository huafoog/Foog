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
	/// 对象存储配置表
	/// </summary>
	[Table(Name = "SysOssConfig")]
	public class SysOssConfigEntity {

		/// <summary>
		/// 主建
		/// </summary>
		public long OssConfigId { get; set; }

		/// <summary>
		/// accessKey
		/// </summary>
		public string AccessKey { get; set; }

		/// <summary>
		/// 桶权限类型(0=private 1=public 2=custom)
		/// </summary>
		public string AccessPolicy { get; set; } = "1";

		/// <summary>
		/// 桶名称
		/// </summary>
		public string BucketName { get; set; }

		/// <summary>
		/// 配置key
		/// </summary>
		public string ConfigKey { get; set; }

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
		/// 自定义域名
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// 访问站点
		/// </summary>
		public string Endpoint { get; set; }

		/// <summary>
		/// 扩展字段
		/// </summary>
		public string Ext1 { get; set; }

		/// <summary>
		/// 是否https（Y=是,N=否）
		/// </summary>
		public string IsHttps { get; set; } = "N";

		/// <summary>
		/// 前缀
		/// </summary>
		public string Prefix { get; set; }

		/// <summary>
		/// 域
		/// </summary>
		public string Region { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 秘钥
		/// </summary>
		public string SecretKey { get; set; }

		/// <summary>
		/// 是否默认（0=是,1=否）
		/// </summary>
		public string Status { get; set; } = "1";

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
