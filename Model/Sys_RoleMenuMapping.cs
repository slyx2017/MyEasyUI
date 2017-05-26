using System;
namespace Model
{
	/// <summary>
	/// Sys_RoleMenuMapping:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_RoleMenuMapping
	{
		public Sys_RoleMenuMapping()
		{}
		#region Model
		private int? _roleid;
		private int? _menuid;
		private int? _menucode;
		/// <summary>
		/// 
		/// </summary>
		public int? RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuID
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuCode
		{
			set{ _menucode=value;}
			get{return _menucode;}
		}
		#endregion Model

	}
}

