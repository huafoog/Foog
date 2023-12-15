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
	/// 通知公告表
	/// </summary>
	[Table(Name = "SysNotice")]
	public class SysNoticeEntity {

		/// <summary>
		/// 公告ID
		/// </summary>
		public long NoticeId { get; set; }

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
		/// 公告内容
		/// </summary>
		public byte[] NoticeContent { get; set; }

		/// <summary>
		/// 公告标题
		/// </summary>
		public string NoticeTitle { get; set; }

		/// <summary>
		/// 公告类型（1通知 2公告）
		/// </summary>
		public string NoticeType { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 公告状态（0正常 1关闭）
		/// </summary>
		public string Status { get; set; } = "0";

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
