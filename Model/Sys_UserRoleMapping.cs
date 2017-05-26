using System;
namespace Model
{
	/// <summary>
	/// Sys_UserRoleMapping:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_UserRoleMapping
	{
		public Sys_UserRoleMapping()
		{}
		#region Model
		private int? _userid;
		private int? _roleid;
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model

	}
}

