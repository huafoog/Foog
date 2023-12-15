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
	/// 租户表
	/// </summary>
	[Table(Name = "SysTenant")]
	public class SysTenantEntity {

		/// <summary>
		/// id
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 用户数量（-1不限制）
		/// </summary>
		public int? AccountCount { get; set; } = -1;

		/// <summary>
		/// 地址
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// 企业名称
		/// </summary>
		public string CompanyName { get; set; }

		/// <summary>
		/// 联系电话
		/// </summary>
		public string ContactPhone { get; set; }

		/// <summary>
		/// 联系人
		/// </summary>
		public string ContactUserName { get; set; }

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
		/// 删除标志（0代表存在 2代表删除）
		/// </summary>
		public string DelFlag { get; set; } = "0";

		/// <summary>
		/// 域名
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// 过期时间
		/// </summary>
		public DateTime? ExpireTime { get; set; }

		/// <summary>
		/// 企业简介
		/// </summary>
		public string Intro { get; set; }

		/// <summary>
		/// 统一社会信用代码
		/// </summary>
		public string LicenseNumber { get; set; }

		/// <summary>
		/// 租户套餐编号
		/// </summary>
		public long? PackageId { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 租户状态（0正常 1停用）
		/// </summary>
		public string Status { get; set; } = "0";

		/// <summary>
		/// 租户编号
		/// </summary>
		public string TenantId { get; set; }

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
