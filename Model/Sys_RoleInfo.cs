using System;
namespace Model
{
	/// <summary>
	/// Sys_RoleInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_RoleInfo
	{
		public Sys_RoleInfo()
		{}
		#region Model
		private int _roleid;
		private string _rolename;
		private string _roledesc;
		private string _writeright;
		private DateTime? _addtime;
		private string _adduser;
		/// <summary>
		/// 
		/// </summary>
		public int RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleDesc
		{
			set{ _roledesc=value;}
			get{return _roledesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WriteRight
		{
			set{ _writeright=value;}
			get{return _writeright;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
		}
		#endregion Model

	}
}

