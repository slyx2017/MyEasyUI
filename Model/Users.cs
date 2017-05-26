using System;
namespace Model
{
	/// <summary>
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Users
	{
		public Users()
		{}
		#region Model
		private int _uid;
		private string _uname;
		private string _uloginname;
		private string _upwd;
		private DateTime _uaddtime;
		private bool _uisdel;
		private bool _sex;
		private string _telephone;
		private string _email;
		private DateTime? _birthday;
		private int? _accountstate;
		private int? _powerLevelid;
		/// <summary>
		/// 
		/// </summary>
		public int uId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uName
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uLoginName
		{
			set{ _uloginname=value;}
			get{return _uloginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uPwd
		{
			set{ _upwd=value;}
			get{return _upwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime uAddtime
		{
			set{ _uaddtime=value;}
			get{return _uaddtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool uIsDel
		{
			set{ _uisdel=value;}
			get{return _uisdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AccountState
		{
			set{ _accountstate=value;}
			get{return _accountstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PowerLevelID
		{
			set{ _powerLevelid=value;}
			get{return _powerLevelid;}
		}
		#endregion Model

	}
}

