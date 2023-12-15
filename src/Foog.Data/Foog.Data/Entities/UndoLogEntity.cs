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
	/// AT transaction mode undo table
	/// </summary>
	[Table(Name = "UndoLog")]
	public class UndoLogEntity {

		/// <summary>
		/// branch transaction id
		/// </summary>
		public long BranchId { get; set; }

		/// <summary>
		/// undo_log context,such as serialization
		/// </summary>
		public string Context { get; set; }

		/// <summary>
		/// create datetime
		/// </summary>
		public DateTime LogCreated { get; set; }

		/// <summary>
		/// modify datetime
		/// </summary>
		public DateTime LogModified { get; set; }

		/// <summary>
		/// 0:normal status,1:defense status
		/// </summary>
		public int LogStatus { get; set; }

		/// <summary>
		/// rollback info
		/// </summary>
		public byte[] RollbackInfo { get; set; }

		/// <summary>
		/// global transaction id
		/// </summary>
		public string Xid { get; set; }

	}

}
