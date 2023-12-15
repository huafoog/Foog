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
	/// 菜单权限表
	/// </summary>
	[Table(Name = "SysMenu")]
	public class SysMenuEntity {

		/// <summary>
		/// 菜单ID
		/// </summary>
		public long MenuId { get; set; }

		/// <summary>
		/// 组件路径
		/// </summary>
		public string Component { get; set; }

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
		/// 菜单图标
		/// </summary>
		public string Icon { get; set; } = "#";

		/// <summary>
		/// 是否缓存（0缓存 1不缓存）
		/// </summary>
		public int? IsCache { get; set; } = 0;

		/// <summary>
		/// 是否为外链（0是 1否）
		/// </summary>
		public int? IsFrame { get; set; } = 1;

		/// <summary>
		/// 菜单名称
		/// </summary>
		public string MenuName { get; set; }

		/// <summary>
		/// 菜单类型（M目录 C菜单 F按钮）
		/// </summary>
		public string MenuType { get; set; }

		/// <summary>
		/// 显示顺序
		/// </summary>
		public int? OrderNum { get; set; } = 0;

		/// <summary>
		/// 父菜单ID
		/// </summary>
		public long? ParentId { get; set; } = 0;

		/// <summary>
		/// 路由地址
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// 权限标识
		/// </summary>
		public string Perms { get; set; }

		/// <summary>
		/// 路由参数
		/// </summary>
		public string QueryParam { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 菜单状态（0正常 1停用）
		/// </summary>
		public string Status { get; set; } = "0";

		/// <summary>
		/// 更新者
		/// </summary>
		public long? UpdateBy { get; set; }

		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime? UpdateTime { get; set; }

		/// <summary>
		/// 显示状态（0显示 1隐藏）
		/// </summary>
		public string Visible { get; set; } = "0";

	}

}
