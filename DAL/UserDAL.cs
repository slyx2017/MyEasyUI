using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:Users
	/// </summary>
	public partial class UserDAL
	{
		public UserDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("uId", "Users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int uId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where uId=@uId");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.Int,4)
			};
			parameters[0].Value = uId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Users(");
			strSql.Append("uName,uLoginName,uPwd,uAddtime,uIsDel,Sex,Telephone,Email,Birthday,AccountState,PowerLevelID)");
			strSql.Append(" values (");
			strSql.Append("@uName,@uLoginName,@uPwd,@uAddtime,@uIsDel,@Sex,@Telephone,@Email,@Birthday,@AccountState,@PowerLevelID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@uName", SqlDbType.NVarChar,20),
					new SqlParameter("@uLoginName", SqlDbType.NVarChar,20),
					new SqlParameter("@uPwd", SqlDbType.NVarChar,64),
					new SqlParameter("@uAddtime", SqlDbType.DateTime),
					new SqlParameter("@uIsDel", SqlDbType.Bit,1),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,11),
					new SqlParameter("@Email", SqlDbType.NVarChar,30),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@AccountState", SqlDbType.TinyInt,1),
					new SqlParameter("@PowerLevelID", SqlDbType.Int,4)};
			parameters[0].Value = model.uName;
			parameters[1].Value = model.uLoginName;
			parameters[2].Value = model.uPwd;
			parameters[3].Value = model.uAddtime;
			parameters[4].Value = model.uIsDel;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.Telephone;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.Birthday;
			parameters[9].Value = model.AccountState;
			parameters[10].Value = model.PowerLevelID;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddNewUser(Model.Users model,int roleId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@uName", SqlDbType.NVarChar,20),
                    new SqlParameter("@uLoginName", SqlDbType.NVarChar,20),
                    new SqlParameter("@uPwd", SqlDbType.NVarChar,64),
                    new SqlParameter("@uAddtime", SqlDbType.DateTime),
                    new SqlParameter("@uIsDel", SqlDbType.Bit,1),
                    new SqlParameter("@Sex", SqlDbType.Bit,1),
                    new SqlParameter("@Telephone", SqlDbType.NVarChar,11),
                    new SqlParameter("@Email", SqlDbType.NVarChar,30),
                    new SqlParameter("@Birthday", SqlDbType.DateTime),
                    new SqlParameter("@AccountState", SqlDbType.TinyInt,1),
                    new SqlParameter("@PowerLevelID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.uName;
            parameters[1].Value = model.uLoginName;
            parameters[2].Value = model.uPwd;
            parameters[3].Value = model.uAddtime;
            parameters[4].Value = model.uIsDel;
            parameters[5].Value = model.Sex;
            parameters[6].Value = model.Telephone;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.Birthday;
            parameters[9].Value = model.AccountState;
            parameters[10].Value = model.PowerLevelID;
            parameters[11].Value = roleId;
            int result = 0;
            object obj = DbHelperSQL.RunProcedure("AddNewUser", parameters, out result);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			strSql.Append("uName=@uName,");
			strSql.Append("uLoginName=@uLoginName,");
			strSql.Append("uPwd=@uPwd,");
			strSql.Append("uAddtime=@uAddtime,");
			strSql.Append("uIsDel=@uIsDel,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Telephone=@Telephone,");
			strSql.Append("Email=@Email,");
			strSql.Append("Birthday=@Birthday,");
			strSql.Append("AccountState=@AccountState,");
			strSql.Append("PowerLevelID=@PowerLevelID");
			strSql.Append(" where uId=@uId");
			SqlParameter[] parameters = {
					new SqlParameter("@uName", SqlDbType.NVarChar,20),
					new SqlParameter("@uLoginName", SqlDbType.NVarChar,20),
					new SqlParameter("@uPwd", SqlDbType.NVarChar,64),
					new SqlParameter("@uAddtime", SqlDbType.DateTime),
					new SqlParameter("@uIsDel", SqlDbType.Bit,1),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,11),
					new SqlParameter("@Email", SqlDbType.NVarChar,30),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@AccountState", SqlDbType.TinyInt,1),
					new SqlParameter("@PowerLevelID", SqlDbType.Int,4),
                    new SqlParameter("@uId", SqlDbType.Int,4)};
			parameters[0].Value = model.uName;
			parameters[1].Value = model.uLoginName;
			parameters[2].Value = model.uPwd;
			parameters[3].Value = model.uAddtime;
			parameters[4].Value = model.uIsDel;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.Telephone;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.Birthday;
			parameters[9].Value = model.AccountState;
			parameters[10].Value = model.PowerLevelID;
			parameters[11].Value = model.uId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int EditUser(Model.Users model,int roleId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@uName", SqlDbType.NVarChar,20),
                    new SqlParameter("@uLoginName", SqlDbType.NVarChar,20),
                    new SqlParameter("@Sex", SqlDbType.Bit,1),
                    new SqlParameter("@Telephone", SqlDbType.NVarChar,11),
                    new SqlParameter("@Email", SqlDbType.NVarChar,30),
                    new SqlParameter("@Birthday", SqlDbType.DateTime),
                    new SqlParameter("@PowerLevelID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@uId", SqlDbType.Int,4)};
            parameters[0].Value = model.uName;
            parameters[1].Value = model.uLoginName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Telephone;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.PowerLevelID;
            parameters[7].Value = roleId;
            parameters[8].Value = model.uId;
            int result = 0;
            return DbHelperSQL.RunProcedure("ModifyUser", parameters, out result);
        }
        /// <summary>
        /// 冻结一条数据
        /// </summary>
        public int FreezeUser(int uId, int state)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@uId", SqlDbType.Int,4),
                    new SqlParameter("@AccountState", SqlDbType.TinyInt,1)
            };
            parameters[0].Value = uId;
            parameters[1].Value = state;
            int result = 0;
            return DbHelperSQL.RunProcedure("FreezeUser", parameters, out result);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int uId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where uId=@uId");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.Int,4)
			};
			parameters[0].Value = uId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteUserByID(int uId,int uIsDel)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@uId", SqlDbType.Int,4),
                    new SqlParameter("@uIsDel", SqlDbType.Bit,1)
            };
            parameters[0].Value = uId;
            parameters[1].Value = uIsDel;
            int result = 0;
            return DbHelperSQL.RunProcedure("DeleteUserByID", parameters, out result);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string uIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where uId in ("+uIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Users GetModel(int uId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 uId,uName,uLoginName,uPwd,uAddtime,uIsDel,Sex,Telephone,Email,Birthday,AccountState,PowerLevelID from Users ");
			strSql.Append(" where uId=@uId");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.Int,4)
			};
			parameters[0].Value = uId;

			Model.Users model=new Model.Users();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Users DataRowToModel(DataRow row)
		{
			Model.Users model=new Model.Users();
			if (row != null)
			{
				if(row["uId"]!=null && row["uId"].ToString()!="")
				{
					model.uId=int.Parse(row["uId"].ToString());
				}
				if(row["uName"]!=null)
				{
					model.uName=row["uName"].ToString();
				}
				if(row["uLoginName"]!=null)
				{
					model.uLoginName=row["uLoginName"].ToString();
				}
				if(row["uPwd"]!=null)
				{
					model.uPwd=row["uPwd"].ToString();
				}
				if(row["uAddtime"]!=null && row["uAddtime"].ToString()!="")
				{
					model.uAddtime=DateTime.Parse(row["uAddtime"].ToString());
				}
				if(row["uIsDel"]!=null && row["uIsDel"].ToString()!="")
				{
					if((row["uIsDel"].ToString()=="1")||(row["uIsDel"].ToString().ToLower()=="true"))
					{
						model.uIsDel=true;
					}
					else
					{
						model.uIsDel=false;
					}
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					if((row["Sex"].ToString()=="1")||(row["Sex"].ToString().ToLower()=="true"))
					{
						model.Sex=true;
					}
					else
					{
						model.Sex=false;
					}
				}
				if(row["Telephone"]!=null)
				{
					model.Telephone=row["Telephone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Birthday"]!=null && row["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(row["Birthday"].ToString());
				}
				if(row["AccountState"]!=null && row["AccountState"].ToString()!="")
				{
					model.AccountState=int.Parse(row["AccountState"].ToString());
				}
				if(row["PowerLevelID"] !=null && row["PowerLevelID"].ToString() != "")
                {
					model.PowerLevelID = int.Parse(row["PowerLevelID"].ToString());
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select uId,uName,uLoginName,uPwd,uAddtime,uIsDel,Sex,Telephone,Email,Birthday,AccountState,PowerLevelID ");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetUserList(string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@strWhere", SqlDbType.NVarChar, 1000)
                    };
            parameters[0].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetUserList", parameters, "ds");
        }
        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="uLoginName">用户名</param>
        /// <param name="uPwd">密码</param>
        /// <returns></returns>
        public DataSet GetUserByLoginName(string uLoginName, string uPwd)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@uLoginName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@uPwd", SqlDbType.NVarChar, 64)
                    };
            parameters[0].Value = uLoginName;
            parameters[1].Value = uPwd;
            return DbHelperSQL.RunProcedure("GetUserByLoginName", parameters, "ds");
        }
	
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetPageList(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000)
                    };
            parameters[0].Value = "Users";
            parameters[1].Value = "uId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetPageList", parameters, "ds");
        }
        #endregion  ExtensionMethod
    }
}

