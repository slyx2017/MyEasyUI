using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:Sys_RoleInfo
	/// </summary>
	public partial class Sys_RoleInfoDAL
	{
		public Sys_RoleInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RoleID", "Sys_RoleInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_RoleInfo");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Sys_RoleInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_RoleInfo(");
			strSql.Append("RoleName,RoleDesc,WriteRight,AddTime,AddUser)");
			strSql.Append(" values (");
			strSql.Append("@RoleName,@RoleDesc,@WriteRight,@AddTime,@AddUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
					new SqlParameter("@RoleDesc", SqlDbType.NVarChar,200),
					new SqlParameter("@WriteRight", SqlDbType.NVarChar,250),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.RoleName;
			parameters[1].Value = model.RoleDesc;
			parameters[2].Value = model.WriteRight;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.AddUser;

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
        /// 新增角色
        /// </summary>
        public int AddNewRole(Model.Sys_RoleInfo model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
                    new SqlParameter("@RoleDesc", SqlDbType.NVarChar,200),
                    new SqlParameter("@WriteRight", SqlDbType.NVarChar,250),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleDesc;
            parameters[2].Value = model.WriteRight;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.AddUser;
            int result = 0;
            return DbHelperSQL.RunProcedure("AddNewRole", parameters, out result);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Sys_RoleInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_RoleInfo set ");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("RoleDesc=@RoleDesc,");
			strSql.Append("WriteRight=@WriteRight,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("AddUser=@AddUser");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
					new SqlParameter("@RoleDesc", SqlDbType.NVarChar,200),
					new SqlParameter("@WriteRight", SqlDbType.NVarChar,250),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleName;
			parameters[1].Value = model.RoleDesc;
			parameters[2].Value = model.WriteRight;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.AddUser;
			parameters[5].Value = model.RoleID;

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
        /// 编辑角色
        /// </summary>
        public int EditRole(Model.Sys_RoleInfo model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
                    new SqlParameter("@RoleDesc", SqlDbType.NVarChar,200),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleDesc;
            parameters[2].Value = model.RoleID;
            int result = 0;
            return DbHelperSQL.RunProcedure("EditRole", parameters, out result);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_RoleInfo ");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string RoleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_RoleInfo ");
			strSql.Append(" where RoleID in ("+RoleIDlist + ")  ");
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
		public Model.Sys_RoleInfo GetModel(int RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleID,RoleName,RoleDesc,WriteRight,AddTime,AddUser from Sys_RoleInfo ");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

			Model.Sys_RoleInfo model=new Model.Sys_RoleInfo();
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
		public Model.Sys_RoleInfo DataRowToModel(DataRow row)
		{
			Model.Sys_RoleInfo model=new Model.Sys_RoleInfo();
			if (row != null)
			{
				if(row["RoleID"]!=null && row["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(row["RoleID"].ToString());
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["RoleDesc"]!=null)
				{
					model.RoleDesc=row["RoleDesc"].ToString();
				}
				if(row["WriteRight"]!=null)
				{
					model.WriteRight=row["WriteRight"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["AddUser"]!=null)
				{
					model.AddUser=row["AddUser"].ToString();
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
			strSql.Append("select RoleID,RoleName,RoleDesc,WriteRight,AddTime,AddUser ");
			strSql.Append(" FROM Sys_RoleInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得角色列表
        /// </summary>
        public DataSet GetRoleList(string strWhere,int roleId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@strWhere", SqlDbType.NVarChar,1000),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)
                    };
            parameters[0].Value = strWhere;
            parameters[1].Value = roleId;
            return DbHelperSQL.RunProcedure("GetRoleList", parameters, "ds");
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" RoleID,RoleName,RoleDesc,WriteRight,AddTime,AddUser ");
			strSql.Append(" FROM Sys_RoleInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Sys_RoleInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.RoleID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_RoleInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetPageList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Sys_RoleInfo";
			parameters[1].Value = "RoleID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 1;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("GetPageList", parameters,"ds");
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

