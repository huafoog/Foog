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
	/// 社会化关系表
	/// </summary>
	[Table(Name = "SysSocial")]
	public class SysSocialEntity {

		/// <summary>
		/// 主键
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 平台的授权信息，部分平台可能没有
		/// </summary>
		public string AccessCode { get; set; }

		/// <summary>
		/// 用户的授权令牌
		/// </summary>
		public string AccessToken { get; set; }

		/// <summary>
		/// 平台+平台唯一id
		/// </summary>
		public string AuthId { get; set; }

		/// <summary>
		/// 头像地址
		/// </summary>
		public string Avatar { get; set; }

		/// <summary>
		/// 用户的授权code，部分平台可能没有
		/// </summary>
		public string Code { get; set; }

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
		/// 用户邮箱
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// 用户的授权令牌的有效期，部分平台可能没有
		/// </summary>
		public int? ExpireIn { get; set; }

		/// <summary>
		/// id token，部分平台可能没有
		/// </summary>
		public string IdToken { get; set; }

		/// <summary>
		/// 小米平台用户的附带属性，部分平台可能没有
		/// </summary>
		public string MacAlgorithm { get; set; }

		/// <summary>
		/// 小米平台用户的附带属性，部分平台可能没有
		/// </summary>
		public string MacKey { get; set; }

		/// <summary>
		/// 用户昵称
		/// </summary>
		public string NickName { get; set; }

		/// <summary>
		/// Twitter平台用户的附带属性，部分平台可能没有
		/// </summary>
		public string OauthToken { get; set; }

		/// <summary>
		/// Twitter平台用户的附带属性，部分平台可能没有
		/// </summary>
		public string OauthTokenSecret { get; set; }

		/// <summary>
		/// 平台编号唯一id
		/// </summary>
		public string OpenId { get; set; }

		/// <summary>
		/// 刷新令牌，部分平台可能没有
		/// </summary>
		public string RefreshToken { get; set; }

		/// <summary>
		/// 授予的权限，部分平台可能没有
		/// </summary>
		public string Scope { get; set; }

		/// <summary>
		/// 用户来源
		/// </summary>
		public string Source { get; set; }

		/// <summary>
		/// 租户id
		/// </summary>
		public string TenantId { get; set; }

		/// <summary>
		/// 个别平台的授权信息，部分平台可能没有
		/// </summary>
		public string TokenType { get; set; }

		/// <summary>
		/// 用户的 unionid
		/// </summary>
		public string UnionId { get; set; }

		/// <summary>
		/// 更新者
		/// </summary>
		public long? UpdateBy { get; set; }

		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime? UpdateTime { get; set; }

		/// <summary>
		/// 用户ID
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 登录账号
		/// </summary>
		public string UserName { get; set; }

	}

}
